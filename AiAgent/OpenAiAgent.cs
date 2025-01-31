using Newtonsoft.Json;

namespace AiAgent;


using RestSharp;
using System.Text.Json;

public class OpenAiRequest
{
    public string model { get; set; }
    public bool store { get; set; }
    public Message[] messages { get; set; }
}

public class Message
{
    public string role { get; set; }
    public string content { get; set; }
}

public class OpenAiClient : IAiAgent
{
    private readonly RestClient _client;
    private readonly string _apiKey;


    private readonly string _generalPrompt1 =
        $"I own a Shopify webset." +
        $"You are a helpful marketing and SEO expert how responds in a professional but friendly tone." +
        $"Please analyse my products and give me advice on them.  This advice should be general.  " +
        $"Do not recommend specific changes to a product, except to use as an example of changes that might be made.  " +
        $"Provide approximately 10 suggestions, but you may provide more or fewer as appropriate." +
        $"For each recommendation, provide:  " +
        $" - a title (in bold)." +
        $" - an observation" +
        $" - a recommendation for improvement" +
        $"Do not end with a sentence inviting more questions." +
        $"My goals:" +
        $"- To attract additional custom    ers" +
        $"- to make the website more engaging" +
        $"- to attract and retain customers" +
        $"" +
        $"Here are my products:";


    private readonly string _detailedPrompt1 =
        $"I own a Shopify website." +
        $"You are a helpful marketing and SEO expert how responds in a professional but friendly tone." +
        $"Please analyse my website entry for this invidual product.  I'm looking for detailed advice on how to change the description, title, price and image(s).  " +
        $"I'm also looking for SEO advice on how to get more sales." +
        $"" +
        $"You will be providing the response in two parts:" +
        $"" +
        $"Part 1:" +
        $"Do not make introductory or final remarks in the response.  Only give the recommendations." +
        $"For each recommendation, provide:" +
        $" - the current value" +
        $" - the recommended value" +
        $" - an observation or a rationale for the recommendation" +
        $"" +
        $"Do not use html tags in the recommendations, except for links.  Instead use markdown where appropriate." +
        $"The text in Part 1 should be fully formated, and sections bolded where appropriate.  Different sections should be separated by a blank line." +
        $"When referring to an external file, create a link to the file.  In Part 1, escape any quotes (\").." +
        $"" +
        $"" +
        $"Part 2:" +
        $"Part2 will be a structured json product will the same format as the input." +
        $"Do not include attributes that are not changed.  Do not make suggestions in part 2; provide only the recommended values as these will be posted to the website." +
        $"" +
        $"The entire response should be structured as a json object with the following structure:" +
        "{\"Part1\":\"<Part1 response>\", \"Part2\" : \"<Part2 response>\"}" +
        $"Here is the product:";

    private string productListClass = string.Empty;

    public OpenAiClient(string apiKey)
    {
        _apiKey = apiKey;
        var options = new RestClientOptions("https://api.openai.com/v1")
        {
            ThrowOnAnyError = true,
            MaxTimeout = 30000
        };
        _client = new RestClient(options);
    }

    public string QueryAgent(string products)
    {
        if (this.productListClass != products)
            this.productListClass = products;

        var request = new RestRequest("/chat/completions", Method.Post);

        var requestBody = new OpenAiRequest
        {
            model = "gpt-4o-mini",
            store = true,
            messages = new Message[]
            {
                new Message
                {
                    role = "user",
                    content = $"{_generalPrompt1}" +
                              $"{products}"
                }
            }
        };

        request.AddHeader("Authorization", $"Bearer {_apiKey}");
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(requestBody);

        try
        {
            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                return ExtractContent(response.Content ?? "{}");

            }

            throw new Exception($"API call failed: {response.ErrorMessage}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error making OpenAI API call: {ex.Message}", ex);
        }
    }

    public string GetDetailedRecommendation(long productId, string products)
    {
        if (this.productListClass != products)
            this.productListClass = products;

        var productList = JsonConvert.DeserializeObject<ProductList>(products);
        var product = productList?.Products?.FirstOrDefault(x => x.Id == productId);
        var productJSon = JsonConvert.SerializeObject(product);

        var request = new RestRequest("/chat/completions", Method.Post);

        var requestBody = new OpenAiRequest
        {
            model = "gpt-4o-mini",
            store = true,
            messages = new Message[]
            {
                new Message
                {
                    role = "user",
                    content = $"{_detailedPrompt1}" +
                              $"{productJSon}"
                }
            }
        };

        request.AddHeader("Authorization", $"Bearer {_apiKey}");
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(requestBody);

        try
        {
            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                return ExtractContent(response.Content ?? "{}");

            }

            throw new Exception($"API call failed: {response.ErrorMessage}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error making OpenAI API call: {ex.Message}", ex);
        }
    }

    public static string ExtractContent(string jsonResponse)
    {
        using JsonDocument document = JsonDocument.Parse(jsonResponse);
        JsonElement root = document.RootElement;

        JsonElement choices = root.GetProperty("choices");
        if (choices.GetArrayLength() > 0)
        {
            JsonElement firstChoice = choices[0];
            JsonElement message = firstChoice.GetProperty("message");
            JsonElement content = message.GetProperty("content");

            return content.GetString();
        }

        return string.Empty;
    }
}

// Example usage:
/*
var client = new OpenAiClient("your-api-key-here");
var response = await client.CreateChatCompletionAsync("write a haiku about ai");
*/