namespace SkincareAI.API.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ProductCategory Category { get; set; }
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<string> Ingredients { get; set; } = new();
        public List<SkinType> SuitableForSkinTypes { get; set; } = new();
        public List<string> Benefits { get; set; } = new();
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}