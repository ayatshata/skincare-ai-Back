using SkincareAI.API.Models.Entities;
using SkincareAI.API.Models.Enums;
using SkincareAI.API.Models.Requests;

namespace SkincareAI.API.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int productId);
        Task<List<Product>> SearchProductsAsync(ProductSearchRequest request);
        Task<List<Product>> GetProductsBySkinTypeAsync(SkinType skinType);
        Task<List<Product>> GetProductsByIngredientsAsync(List<string> ingredients);
        Task<List<Product>> GetProductsByCategoryAsync(ProductCategory category);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int productId);
    }
}