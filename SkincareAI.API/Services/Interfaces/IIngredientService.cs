using SkincareAI.API.Models.Entities;

namespace SkincareAI.API.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<Ingredient?> GetIngredientByNameAsync(string name);
        Task<List<Ingredient>> SearchIngredientsAsync(string query);
        Task<List<Ingredient>> GetIngredientsByBenefitsAsync(List<string> benefits);
        Task<List<Ingredient>> GetCompatibleIngredientsAsync(List<string> ingredientNames);
    }
}