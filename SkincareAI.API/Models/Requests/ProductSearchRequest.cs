namespace SkincareAI.API.Models.Requests
{
    public class ProductSearchRequest
    {
        public string? Query { get; set; }
        public ProductCategory? Category { get; set; }
        public SkinType? SkinType { get; set; }
        public List<string>? Ingredients { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}