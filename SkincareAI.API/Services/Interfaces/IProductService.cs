using SkincareAI.API.Models.Entities;
using SkincareAI.API.Models.Requests;
using SkincareAI.API.Models.Responses;

namespace SkincareAI.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductRecommendationResponse>> SearchProductsAsync(ProductSearchRequest request);
        Task<Product?> GetProductByIdAsync(int productId);
        Task<List<ProductRecommendationResponse>> GetRecommendedProductsAsync(SkinType skinType, List<string> concerns);
        Task<List<Product>> GetProductsByIngredientsAsync(List<string> ingredients);
    }
}