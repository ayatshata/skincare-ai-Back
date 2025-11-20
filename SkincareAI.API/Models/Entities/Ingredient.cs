namespace SkincareAI.API.Models.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Benefits { get; set; } = new();
        public List<string> SideEffects { get; set; } = new();
        public List<SkinType> SuitableForSkinTypes { get; set; } = new();
        public List<SkinType> NotSuitableForSkinTypes { get; set; } = new();
    }
}