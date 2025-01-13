using Newtonsoft.Json;
using ProductsAgent.Models;

public class ProductList
{
    [JsonProperty("products")]
    public List<Product> Products { get; set; }

    public ProductList()
    {
        Products = new List<Product>();
    }
}

namespace ProductsAgent.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body_html")]
        public string BodyHtml { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("published_scope")]
        public string PublishedScope { get; set; }

        [JsonProperty("admin_graphql_api_id")]
        public string AdminGraphqlApiId { get; set; }
    }


}
