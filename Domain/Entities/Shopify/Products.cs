using Newtonsoft.Json;


public class ProductList
{
    [JsonProperty("products")]
    public List<Product> Products { get; set; }

    public ProductList()
    {
        Products = new List<Product>();
    }
}


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

    [JsonProperty("handle")]
    public string Handle { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("published_at")]
    public DateTime PublishedAt { get; set; }

    [JsonProperty("template_suffix")]
    public string TemplateSuffix { get; set; }

    [JsonProperty("published_scope")]
    public string PublishedScope { get; set; }

    [JsonProperty("tags")]
    public string Tags { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("admin_graphql_api_id")]
    public string AdminGraphqlApiId { get; set; }

    [JsonProperty("variants")]
    public List<Variant> Variants { get; set; }

    [JsonProperty("options")]
    public List<Option> Options { get; set; }

    [JsonProperty("images")]
    public List<Image> Images { get; set; }

    [JsonProperty("image")]
    public Image Image { get; set; }
}

public class Variant
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("product_id")]
    public long ProductId { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("price")]
    public string Price { get; set; }

    [JsonProperty("position")]
    public int Position { get; set; }

    [JsonProperty("inventory_policy")]
    public string InventoryPolicy { get; set; }

    [JsonProperty("compare_at_price")]
    public string CompareAtPrice { get; set; }

    [JsonProperty("option1")]
    public string Option1 { get; set; }

    [JsonProperty("option2")]
    public string Option2 { get; set; }

    [JsonProperty("option3")]
    public string Option3 { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("taxable")]
    public bool Taxable { get; set; }

    [JsonProperty("barcode")]
    public string Barcode { get; set; }

    [JsonProperty("fulfillment_service")]
    public string FulfillmentService { get; set; }

    [JsonProperty("grams")]
    public int Grams { get; set; }

    [JsonProperty("inventory_management")]
    public string InventoryManagement { get; set; }

    [JsonProperty("requires_shipping")]
    public bool RequiresShipping { get; set; }

    [JsonProperty("sku")]
    public string Sku { get; set; }

    [JsonProperty("weight")]
    public double Weight { get; set; }

    [JsonProperty("weight_unit")]
    public string WeightUnit { get; set; }

    [JsonProperty("inventory_item_id")]
    public long InventoryItemId { get; set; }

    [JsonProperty("inventory_quantity")]
    public int InventoryQuantity { get; set; }

    [JsonProperty("old_inventory_quantity")]
    public int OldInventoryQuantity { get; set; }

    [JsonProperty("admin_graphql_api_id")]
    public string AdminGraphqlApiId { get; set; }

    [JsonProperty("image_id")]
    public long? ImageId { get; set; }
}

public class Option
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("product_id")]
    public long ProductId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("position")]
    public int Position { get; set; }

    [JsonProperty("values")]
    public List<string> Values { get; set; }
}

public class Image
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("alt")]
    public string Alt { get; set; }

    [JsonProperty("position")]
    public int Position { get; set; }

    [JsonProperty("product_id")]
    public long ProductId { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("admin_graphql_api_id")]
    public string AdminGraphqlApiId { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("src")]
    public string Src { get; set; }

    [JsonProperty("variant_ids")]
    public List<long> VariantIds { get; set; }
}

//namespace ProductsAgent.Models
//{
//    public class Product
//    {
//        [JsonProperty("id")]
//        public long Id { get; set; }

//        [JsonProperty("title")]
//        public string Title { get; set; }

//        [JsonProperty("body_html")]
//        public string HtmlBody { get; set; }

//        [JsonProperty("vendor")]
//        public string Vendor { get; set; }

//        [JsonProperty("product_type")]
//        public string ProductType { get; set; }

//        [JsonProperty("created_at")]
//        public DateTime CreatedAt { get; set; }

//        [JsonProperty("updated_at")]
//        public DateTime UpdatedAt { get; set; }

//        [JsonProperty("handle")]
//        public string Handle { get; set; }

//        [JsonProperty("tags")]
//        public string Tags { get; set; }

//        [JsonProperty("published_scope")]
//        public string PublishedScope { get; set; }

//        [JsonProperty("admin_graphql_api_id")]
//        public string AdminGraphqlApiId { get; set; }

//        [JsonProperty("image")]
//        public Image Image { get; set; }
//    }


//    public class Image
//    {
//        [JsonProperty("src")]
//        public string Src { get; set; }
//    }
//}
