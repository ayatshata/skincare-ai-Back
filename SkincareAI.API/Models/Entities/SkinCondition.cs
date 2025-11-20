namespace SkincareAI.API.Models.Entities
{
    public class SkinCondition
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ConditionSeverity Severity { get; set; }
        public List<string> Symptoms { get; set; } = new();
        public List<string> RecommendedIngredients { get; set; } = new();
        public List<string> AvoidIngredients { get; set; } = new();
    }
}