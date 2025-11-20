using SkincareAI.API.Models.Entities;
using SkincareAI.API.Services.Interfaces;
using SkincareAI.API.Data.Repositories;

namespace SkincareAI.API.Services.Implementations
{
    public class UserHistoryService : IUserHistoryService
    {
        private readonly IUserHistoryRepository _userHistoryRepository;

        public UserHistoryService(IUserHistoryRepository userHistoryRepository)
        {
            _userHistoryRepository = userHistoryRepository;
        }

        public async Task SaveAnalysisHistoryAsync(UserHistory history)
        {
            await _userHistoryRepository.AddAsync(history);
        }

        public async Task<List<UserHistory>> GetUserHistoryAsync(string userId)
        {
            return await _userHistoryRepository.GetByUserIdAsync(userId);
        }

        public async Task<UserHistory?> GetAnalysisHistoryAsync(int historyId)
        {
            return await _userHistoryRepository.GetByIdAsync(historyId);
        }
    }
}