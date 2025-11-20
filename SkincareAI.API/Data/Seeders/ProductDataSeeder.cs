using SkincareAI.API.Data.Contexts;

namespace SkincareAI.API.Data.Seeders
{
    public static class ProductDataSeeder
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SkincareDbContext>();
            var seeder = new DatabaseSeeder(context);

            await seeder.SeedAsync();
        }
    }
}