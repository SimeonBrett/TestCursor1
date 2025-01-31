namespace Entities.Pages.Playground
{
    public class Product
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string BodyHtml { get; set; } = string.Empty;
        public string? Image { get; set; }
    }
}
