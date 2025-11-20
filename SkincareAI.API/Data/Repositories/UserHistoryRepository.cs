using Microsoft.EntityFrameworkCore;
using SkincareAI.API.Data.Contexts;
using SkincareAI.API.Models.Entities;

namespace SkincareAI.API.Data.Repositories
{
    public class UserHistoryRepository : IUserHistoryRepository
    {
        private readonly SkincareDbContext _context;

        public UserHistoryRepository(SkincareDbContext context)
        {
            _context = context;
        }

        public async Task<UserHistory?> GetByIdAsync(int historyId)
        {
            return await _context.UserHistories
                .FirstOrDefaultAsync(h => h.Id == historyId);
        }

        public async Task<List<UserHistory>> GetByUserIdAsync(string userId)
        {
            return await _context.UserHistories
                .Where(h => h.UserId == userId)
                .OrderByDescending(h => h.CreatedAt)
                .Take(20)
                .ToListAsync();
        }

        public async Task AddAsync(UserHistory history)
        {
            await _context.UserHistories.AddAsync(history);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserHistory history)
        {
            _context.UserHistories.Update(history);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int historyId)
        {
            var history = await GetByIdAsync(historyId);
            if (history != null)
            {
                _context.UserHistories.Remove(history);
                await _context.SaveChangesAsync();
            }
        }
    }
}