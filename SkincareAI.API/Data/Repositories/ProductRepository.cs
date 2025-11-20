using Microsoft.EntityFrameworkCore;
using SkincareAI.API.Data.Contexts;
using SkincareAI.API.Models.Entities;
using SkincareAI.API.Models.Enums;
using SkincareAI.API.Models.Requests;

namespace SkincareAI.API.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SkincareDbContext _context;

        public ProductRepository(SkincareDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<Product>> SearchProductsAsync(ProductSearchRequest request)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request.Query))
            {
                query = query.Where(p =>
                    p.Name.Contains(request.Query) ||
                    p.Description.Contains(request.Query) ||
                    p.Brand.Contains(request.Query));
            }

            if (request.Category.HasValue)
            {
                query = query.Where(p => p.Category == request.Category.Value);
            }

            if (request.SkinType.HasValue)
            {
                query = query.Where(p => p.SuitableForSkinTypes.Contains(request.SkinType.Value));
            }

            if (request.Ingredients != null && request.Ingredients.Any())
            {
                query = query.Where(p => p.Ingredients.Any(i => request.Ingredients.Contains(i)));
            }

            if (request.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= request.MaxPrice.Value);
            }

            return await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsBySkinTypeAsync(SkinType skinType)
        {
            return await _context.Products
                .Where(p => p.SuitableForSkinTypes.Contains(skinType))
                .OrderByDescending(p => p.Rating)
                .Take(50)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByIngredientsAsync(List<string> ingredients)
        {
            return await _context.Products
                .Where(p => p.Ingredients.Any(i => ingredients.Contains(i)))
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(ProductCategory category)
        {
            return await _context.Products
                .Where(p => p.Category == category)
                .ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await GetByIdAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}