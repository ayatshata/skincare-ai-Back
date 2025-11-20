namespace SkincareAI.API.Models.Entities
{
    public class UserHistory
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public SkinType SkinType { get; set; }
        public List<string> Concerns { get; set; } = new();
        public List<string> Symptoms { get; set; } = new();
        public string AnalysisResult { get; set; } = string.Empty;
        public List<int> RecommendedProductIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}