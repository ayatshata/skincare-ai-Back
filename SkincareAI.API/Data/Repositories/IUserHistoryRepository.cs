using SkincareAI.API.Models.Entities;

namespace SkincareAI.API.Data.Repositories
{
    public interface IUserHistoryRepository
    {
        Task<UserHistory?> GetByIdAsync(int historyId);
        Task<List<UserHistory>> GetByUserIdAsync(string userId);
        Task AddAsync(UserHistory history);
        Task UpdateAsync(UserHistory history);
        Task DeleteAsync(int historyId);
    }
}