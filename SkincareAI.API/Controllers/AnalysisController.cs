using Microsoft.AspNetCore.Mvc;
using SkincareAI.API.Models.Requests;
using SkincareAI.API.Services.AI;
using SkincareAI.API.Utilities.Helpers;

namespace SkincareAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly ISymptomAnalyzer _symptomAnalyzer;

        public AnalysisController(ISymptomAnalyzer symptomAnalyzer)
        {
            _symptomAnalyzer = symptomAnalyzer;
        }

        [HttpPost("symptoms")]
        public async Task<ActionResult<ApiResponse<object>>> AnalyzeSymptoms(
            [FromBody] SymptomAnalysisRequest request)
        {
            try
            {
                var result = await _symptomAnalyzer.AnalyzeSymptomsAsync(request.Symptoms, request.SkinType);
                return Ok(ResponseHelper.Success(result, "Symptom analysis completed successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.Error<object>(
                    "Analysis failed", new List<string> { ex.Message }));
            }
        }
    }
}