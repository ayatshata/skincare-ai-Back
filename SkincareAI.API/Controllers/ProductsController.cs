using Microsoft.AspNetCore.Mvc;
using SkincareAI.API.Models.Requests;
using SkincareAI.API.Models.Responses;
using SkincareAI.API.Services.Interfaces;
using SkincareAI.API.Utilities.Helpers;

namespace SkincareAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("search")]
        public async Task<ActionResult<ApiResponse<List<ProductRecommendationResponse>>>> SearchProducts(
            [FromBody] ProductSearchRequest request)
        {
            try
            {
                var result = await _productService.SearchProductsAsync(request);
                return Ok(ResponseHelper.Success(result, "Products retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.Error<List<ProductRecommendationResponse>>(
                    "Search failed", new List<string> { ex.Message }));
            }
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ApiResponse<object>>> GetProduct(int productId)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(productId);
                if (product == null)
                    return NotFound(ResponseHelper.Error<object>("Product not found"));

                return Ok(ResponseHelper.Success(product, "Product retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.Error<object>(
                    "Failed to retrieve product", new List<string> { ex.Message }));
            }
        }

        [HttpGet("recommendations")]
        public async Task<ActionResult<ApiResponse<List<ProductRecommendationResponse>>>> GetRecommendations(
            [FromQuery] SkinType skinType, [FromQuery] List<string> concerns)
        {
            try
            {
                var result = await _productService.GetRecommendedProductsAsync(skinType, concerns);
                return Ok(ResponseHelper.Success(result, "Recommendations generated successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.Error<List<ProductRecommendationResponse>>(
                    "Failed to generate recommendations", new List<string> { ex.Message }));
            }
        }
    }
}