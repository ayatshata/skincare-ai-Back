using SkincareAI.API.Models.Requests;
using SkincareAI.API.Models.Responses;

namespace SkincareAI.API.Services.Interfaces
{
    public interface ISkincareAnalysisService
    {
        Task<SkincareAnalysisResponse> AnalyzeSkinAsync(SkincareAnalysisRequest request, string userId);
        Task<SkincareAnalysisResponse> GetAnalysisByIdAsync(string analysisId);
        Task<List<SkincareAnalysisResponse>> GetUserAnalysisHistoryAsync(string userId);
    }
}