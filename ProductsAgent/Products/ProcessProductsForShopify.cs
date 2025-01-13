using Newtonsoft.Json;
using RestSharp;

namespace Products
{
    public class ProcessProductsForShopify : IProcessProducts
    {
        private readonly string _accessToken;
        private readonly string _baseUrl;
        private readonly RestClient _client;

        public ProcessProductsForShopify(string accessToken)
        {
            _accessToken = accessToken;
            _baseUrl = "https://f8development.myshopify.com";
            _client = new RestClient(_baseUrl);
        }

        public ProductList ProductList { get; private set; }


        public string GetAllProducts()
        {
            try
            {
                var request = new RestRequest("/admin/api/2024-10/products.json", Method.Get);

                // Add Shopify access token header
                request.AddHeader("X-Shopify-Access-Token", _accessToken);

                // Execute the request
                var response = _client.Execute(request);

                // Check if the request was successful
                if (response.IsSuccessful)
                {
                    // Deserialize the response content to ProductList
                    ProductList = JsonConvert.DeserializeObject<ProductList>(response.Content ?? "") ?? new ProductList();
                    return response.Content ?? "";
                }
                else
                {
                    throw new Exception($"API call failed with status code: {response.StatusCode}, Error: {response.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calling Shopify API: {ex.Message}", ex);
            }
        }
    }
}
