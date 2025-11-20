using SkincareAI.API.Models.Entities;
using SkincareAI.API.Services.Interfaces;

namespace SkincareAI.API.Services.Implementations
{
    public class IngredientService : IIngredientService
    {
        private readonly List<Ingredient> _ingredients;

        public IngredientService()
        {
            // Mock data - in real app, this would come from database
            _ingredients = new List<Ingredient>
            {
                new Ingredient
                {
                    Id = 1,
                    Name = "Salicylic Acid",
                    Description = "Beta hydroxy acid that exfoliates skin and unclogs pores",
                    Benefits = new List<string> { "Acne treatment", "Exfoliation", "Pore cleansing" },
                    SuitableForSkinTypes = new List<SkinType> { SkinType.Oily, SkinType.Combination },
                    NotSuitableForSkinTypes = new List<SkinType> { SkinType.Sensitive, SkinType.Dry }
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Hyaluronic Acid",
                    Description = "Powerful humectant that attracts and retains moisture",
                    Benefits = new List<string> { "Hydration", "Plumping", "Moisture retention" },
                    SuitableForSkinTypes = new List<SkinType> { SkinType.Dry, SkinType.Normal, SkinType.Combination },
                    NotSuitableForSkinTypes = new List<SkinType> { }
                }
            };
        }

        public async Task<Ingredient?> GetIngredientByNameAsync(string name)
        {
            return await Task.FromResult(_ingredients.FirstOrDefault(i =>
                i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<List<Ingredient>> SearchIngredientsAsync(string query)
        {
            return await Task.FromResult(_ingredients.Where(i =>
                i.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                i.Description.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                i.Benefits.Any(b => b.Contains(query, StringComparison.OrdinalIgnoreCase)))
                .ToList());
        }

        public async Task<List<Ingredient>> GetIngredientsByBenefitsAsync(List<string> benefits)
        {
            return await Task.FromResult(_ingredients.Where(i =>
                benefits.Any(b => i.Benefits.Contains(b, StringComparer.OrdinalIgnoreCase)))
                .ToList());
        }

        public async Task<List<Ingredient>> GetCompatibleIngredientsAsync(List<string> ingredientNames)
        {
        
            return await Task.FromResult(_ingredients.Where(i =>
                ingredientNames.Contains(i.Name, StringComparer.OrdinalIgnoreCase))
                .ToList());
        }
    }
}