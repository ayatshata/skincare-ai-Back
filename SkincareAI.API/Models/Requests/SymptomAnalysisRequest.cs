using SkincareAI.API.Models;

namespace SkincareAI.API.Models.Requests
{
    public class SymptomAnalysisRequest
    {
        public List<string> Symptoms { get; set; } = new();
        public SkinType SkinType { get; set; }
        public int Age { get; set; }
        public string? Lifestyle { get; set; }
    }
}