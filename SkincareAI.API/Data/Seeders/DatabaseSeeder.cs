using SkincareAI.API.Data.Contexts;
using SkincareAI.API.Models.Entities;
using SkincareAI.API.Models.Enums;

namespace SkincareAI.API.Data.Seeders
{
    public class DatabaseSeeder
    {
        private readonly SkincareDbContext _context;

        public DatabaseSeeder(SkincareDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await SeedProducts();
            await _context.SaveChangesAsync();
        }

        private async Task SeedProducts()
        {
            if (!_context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Hydrating Facial Cleanser",
                        Description = "Gentle cleanser that removes impurities without stripping skin",
                        Category = ProductCategory.Cleanser,
                        Brand = "CeraVe",
                        Price = 14.99m,
                        ImageUrl = "/images/cerave-cleanser.jpg",
                        Ingredients = new List<string> { "Ceramides", "Hyaluronic Acid", "Glycerin" },
                        SuitableForSkinTypes = new List<SkinType> { SkinType.Dry, SkinType.Normal, SkinType.Sensitive },
                        Benefits = new List<string> { "Hydration", "Gentle Cleansing", "Barrier Repair" },
                        Rating = 4.5m,
                        ReviewCount = 1250
                    },
                    new Product
                    {
                        Name = "Oil-Free Moisturizer",
                        Description = "Lightweight moisturizer for oily skin",
                        Category = ProductCategory.Moisturizer,
                        Brand = "Neutrogena",
                        Price = 16.99m,
                        ImageUrl = "/images/neutrogena-moisturizer.jpg",
                        Ingredients = new List<string> { "Salicylic Acid", "Niacinamide", "Glycerin" },
                        SuitableForSkinTypes = new List<SkinType> { SkinType.Oily, SkinType.Combination },
                        Benefits = new List<string> { "Oil Control", "Hydration", "Pore Minimizing" },
                        Rating = 4.3m,
                        ReviewCount = 890
                    }
                };

                await _context.Products.AddRangeAsync(products);
            }
        }
    }
}