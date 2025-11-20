using SkincareAI.API.Models.Entities;
using SkincareAI.API.Models.Requests;
using SkincareAI.API.Models.Responses;
using SkincareAI.API.Services.AI;
using SkincareAI.API.Services.Interfaces;
using SkincareAI.API.Data.Repositories;

namespace SkincareAI.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductRecommender _productRecommender;

        public ProductService(IProductRepository productRepository, ProductRecommender productRecommender)
        {
            _productRepository = productRepository;
            _productRecommender = productRecommender;
        }

        public async Task<List<ProductRecommendationResponse>> SearchProductsAsync(ProductSearchRequest request)
        {
            var products = await _productRepository.SearchProductsAsync(request);

            return products.Select(p => new ProductRecommendationResponse
            {
                ProductId = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Brand = p.Brand,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Rating = p.Rating,
                ReviewCount = p.ReviewCount,
                RecommendationReason = "Matches search criteria",
                KeyIngredients = p.Ingredients.Take(5).ToList()
            }).ToList();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }

        public async Task<List<ProductRecommendationResponse>> GetRecommendedProductsAsync(SkinType skinType, List<string> concerns)
        {
            var products = await _productRepository.GetProductsBySkinTypeAsync(skinType);
            var recommended = _productRecommender.RecommendProducts(products, skinType, concerns);

            return recommended.Select(p => new ProductRecommendationResponse
            {
                ProductId = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Brand = p.Brand,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Rating = p.Rating,
                ReviewCount = p.ReviewCount,
                RecommendationReason = $"Suitable for {skinType} skin and addresses {string.Join(", ", concerns.Take(2))}",
                KeyIngredients = p.Ingredients.Take(5).ToList()
            }).ToList();
        }

        public async Task<List<Product>> GetProductsByIngredientsAsync(List<string> ingredients)
        {
            return await _productRepository.GetProductsByIngredientsAsync(ingredients);
        }
    }
}