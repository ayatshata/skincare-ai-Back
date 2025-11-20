using SkincareAI.API.Models.Enums;
using SkincareAI.API.Models.Responses;

namespace SkincareAI.API.Services.AI
{
    public class MockSymptomAnalyzer : ISymptomAnalyzer
    {
        public async Task<SymptomAnalysisResult> AnalyzeSymptomsAsync(List<string> symptoms, SkinType skinType)
        {
            // Mock AI analysis - in real app, this would call an ML model
            await Task.Delay(100); // Simulate processing time

            var conditions = new List<string>();
            var recommendedIngredients = new List<string>();
            var avoidIngredients = new List<string>();

            // Simple rule-based analysis
            if (symptoms.Any(s => s.Contains("acne", StringComparison.OrdinalIgnoreCase) ||
                                 s.Contains("pimple", StringComparison.OrdinalIgnoreCase)))
            {
                conditions.Add("Acne");
                recommendedIngredients.AddRange(new[] { "Salicylic Acid", "Niacinamide", "Benzoyl Peroxide" });
                avoidIngredients.AddRange(new[] { "Heavy Oils", "Comedogenic Ingredients" });
            }

            if (symptoms.Any(s => s.Contains("dry", StringComparison.OrdinalIgnoreCase) ||
                                 s.Contains("flaky", StringComparison.OrdinalIgnoreCase)))
            {
                conditions.Add("Dry Skin");
                recommendedIngredients.AddRange(new[] { "Hyaluronic Acid", "Ceramides", "Glycerin" });
            }

            if (symptoms.Any(s => s.Contains("redness", StringComparison.OrdinalIgnoreCase) ||
                                 s.Contains("sensitive", StringComparison.OrdinalIgnoreCase)))
            {
                conditions.Add("Sensitive Skin");
                recommendedIngredients.AddRange(new[] { "Centella Asiatica", "Niacinamide", "Aloe Vera" });
                avoidIngredients.AddRange(new[] { "Alcohol", "Fragrance", "Essential Oils" });
            }

            return new SymptomAnalysisResult
            {
                IdentifiedConditions = conditions.Distinct().ToList(),
                Summary = $"Based on your symptoms, we've identified {conditions.Count} potential skin concerns. " +
                         $"Your {skinType} skin would benefit from a gentle yet effective routine.",
                RecommendedIngredients = recommendedIngredients.Distinct().ToList(),
                IngredientsToAvoid = avoidIngredients.Distinct().ToList(),
                RoutineAdvice = GetRoutineAdvice(skinType, conditions)
            };
        }

        private string GetRoutineAdvice(SkinType skinType, List<string> conditions)
        {
            var advice = new List<string>
            {
                "• Cleanse twice daily with a gentle cleanser",
                "• Apply moisturizer while skin is still damp",
                "• Use sunscreen every morning"
            };

            if (conditions.Contains("Acne"))
            {
                advice.Add("• Use acne treatments in the evening");
                advice.Add("• Avoid picking or squeezing blemishes");
            }

            if (skinType == SkinType.Dry)
            {
                advice.Add("• Consider using a hydrating serum before moisturizer");
            }

            return string.Join("\n", advice);
        }
    }
}