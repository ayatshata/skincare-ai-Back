using SkincareAI.API.Models.Enums;
using SkincareAI.API.Models.Responses;

namespace SkincareAI.API.Services.AI
{
    public interface ISymptomAnalyzer
    {
        Task<SymptomAnalysisResult> AnalyzeSymptomsAsync(List<string> symptoms, SkinType skinType);
    }

    public class SymptomAnalysisResult
    {
        public List<string> IdentifiedConditions { get; set; } = new();
        public string Summary { get; set; } = string.Empty;
        public List<string> RecommendedIngredients { get; set; } = new();
        public List<string> IngredientsToAvoid { get; set; } = new();
        public string RoutineAdvice { get; set; } = string.Empty;
    }
}