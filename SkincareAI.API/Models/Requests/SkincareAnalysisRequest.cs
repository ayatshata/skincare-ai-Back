namespace SkincareAI.API.Models.Requests
{
    public class SkincareAnalysisRequest
    {
        public SkinType SkinType { get; set; }
        public List<string> Concerns { get; set; } = new();
        public List<string> Symptoms { get; set; } = new();
        public string? AdditionalNotes { get; set; }
    }
}