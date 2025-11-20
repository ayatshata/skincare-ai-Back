using Microsoft.AspNetCore.Mvc;
using SkincareAI.API.Models.Requests;
using SkincareAI.API.Models.Responses;
using SkincareAI.API.Services.Interfaces;
using SkincareAI.API.Utilities.Helpers;

namespace SkincareAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkincareController : ControllerBase
    {
        private readonly ISkincareAnalysisService _analysisService;

        public SkincareController(ISkincareAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        [HttpPost("analyze")]
        public async Task<ActionResult<ApiResponse<SkincareAnalysisResponse>>> AnalyzeSkin(
            [FromBody] SkincareAnalysisRequest request)
        {
            try
            {
                // In real app, get userId from JWT token
                var userId = User?.Identity?.Name ?? "anonymous";

                var result = await _analysisService.AnalyzeSkinAsync(request, userId);
                return Ok(ResponseHelper.Success(result, "Skin analysis completed successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.Error<SkincareAnalysisResponse>(
                    "Analysis failed", new List<string> { ex.Message }));
            }
        }

        [HttpGet("analysis/{analysisId}")]
        public async Task<ActionResult<ApiResponse<SkincareAnalysisResponse>>> GetAnalysis(string analysisId)
        {
            try
            {
                var result = await _analysisService.GetAnalysisByIdAsync(analysisId);
                if (result == null)
                    return NotFound(ResponseHelper.Error<SkincareAnalysisResponse>("Analysis not found"));

                return Ok(ResponseHelper.Success(result, "Analysis retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.Error<SkincareAnalysisResponse>(
                    "Failed to retrieve analysis", new List<string> { ex.Message }));
            }
        }

        [HttpGet("history")]
        public async Task<ActionResult<ApiResponse<List<SkincareAnalysisResponse>>>> GetUserHistory()
        {
            try
            {
                var userId = User?.Identity?.Name ?? "anonymous";
                var result = await _analysisService.GetUserAnalysisHistoryAsync(userId);

                return Ok(ResponseHelper.Success(result, "History retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.Error<List<SkincareAnalysisResponse>>(
                    "Failed to retrieve history", new List<string> { ex.Message }));
            }
        }
    }
}