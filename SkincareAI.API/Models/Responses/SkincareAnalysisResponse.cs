namespace SkincareAI.API.Models.Responses
{
    public class SkincareAnalysisResponse
    {
        public string AnalysisId { get; set; } = string.Empty;
        public SkinType SkinType { get; set; }
        public List<string> IdentifiedConditions { get; set; } = new();
        public string AnalysisSummary { get; set; } = string.Empty;
        public List<string> RecommendedIngredients { get; set; } = new();
        public List<string> IngredientsToAvoid { get; set; } = new();
        public List<ProductRecommendationResponse> RecommendedProducts { get; set; } = new();
        public string RoutineAdvice { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}