using SkincareAI.API.Models.Entities;
using SkincareAI.API.Models.Requests;
using SkincareAI.API.Models.Responses;
using SkincareAI.API.Services.AI;
using SkincareAI.API.Services.Interfaces;

namespace SkincareAI.API.Services.Implementations
{
    public class SkincareAnalysisService : ISkincareAnalysisService
    {
        private readonly ISymptomAnalyzer _symptomAnalyzer;
        private readonly IProductService _productService;
        private readonly IUserHistoryService _userHistoryService;

        public SkincareAnalysisService(
            ISymptomAnalyzer symptomAnalyzer,
            IProductService productService,
            IUserHistoryService userHistoryService)
        {
            _symptomAnalyzer = symptomAnalyzer;
            _productService = productService;
            _userHistoryService = userHistoryService;
        }

        public async Task<SkincareAnalysisResponse> AnalyzeSkinAsync(SkincareAnalysisRequest request, string userId)
        {
     
            var analysisResult = await _symptomAnalyzer.AnalyzeSymptomsAsync(request.Symptoms, request.SkinType);

            var recommendedProducts = await _productService.GetRecommendedProductsAsync(
                request.SkinType, request.Concerns);

            var response = new SkincareAnalysisResponse
            {
                AnalysisId = Guid.NewGuid().ToString(),
                SkinType = request.SkinType,
                IdentifiedConditions = analysisResult.IdentifiedConditions,
                AnalysisSummary = analysisResult.Summary,
                RecommendedIngredients = analysisResult.RecommendedIngredients,
                IngredientsToAvoid = analysisResult.IngredientsToAvoid,
                RecommendedProducts = recommendedProducts,
                RoutineAdvice = analysisResult.RoutineAdvice,
                CreatedAt = DateTime.UtcNow
            };

            // Save to history
            var history = new UserHistory
            {
                UserId = userId,
                SkinType = request.SkinType,
                Concerns = request.Concerns,
                Symptoms = request.Symptoms,
                AnalysisResult = analysisResult.Summary,
                RecommendedProductIds = recommendedProducts.Select(p => p.ProductId).ToList(),
                CreatedAt = DateTime.UtcNow
            };

            await _userHistoryService.SaveAnalysisHistoryAsync(history);

            return response;
        }

        public async Task<SkincareAnalysisResponse> GetAnalysisByIdAsync(string analysisId)
        {
            // Implementation for retrieving specific analysis
            throw new NotImplementedException();
        }

        public async Task<List<SkincareAnalysisResponse>> GetUserAnalysisHistoryAsync(string userId)
        {
            // Implementation for user history
            throw new NotImplementedException();
        }
    }
}