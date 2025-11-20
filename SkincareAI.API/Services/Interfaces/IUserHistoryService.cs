using SkincareAI.API.Models.Entities;

namespace SkincareAI.API.Services.Interfaces
{
    public interface IUserHistoryService
    {
        Task SaveAnalysisHistoryAsync(UserHistory history);
        Task<List<UserHistory>> GetUserHistoryAsync(string userId);
        Task<UserHistory?> GetAnalysisHistoryAsync(int historyId);
    }
}