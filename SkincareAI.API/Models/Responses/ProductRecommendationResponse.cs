using SkincareAI.API.Models.Enums;

namespace SkincareAI.API.Models.Responses
{
    public class ProductRecommendationResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ProductCategory Category { get; set; }
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public string RecommendationReason { get; set; } = string.Empty;
        public List<string> KeyIngredients { get; set; } = new();
    }
}