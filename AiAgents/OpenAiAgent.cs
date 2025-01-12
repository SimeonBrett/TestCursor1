namespace AiAgent;


using RestSharp;

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

    public string QueryAgent(string prompt)
    {
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
                    content = $"I own a store at Shopify.  These are my products.  Please suggest improvements:" +
                              $"{prompt}"
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
                return response.Content ?? string.Empty;

            }

            throw new Exception($"API call failed: {response.ErrorMessage}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error making OpenAI API call: {ex.Message}", ex);
        }
    }
}

// Example usage:
/*
var client = new OpenAiClient("your-api-key-here");
var response = await client.CreateChatCompletionAsync("write a haiku about ai");
*/