using SkincareAI.API.Data.Seeders;

namespace SkincareAI.API.Utilities.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            // Seed database on startup
            ProductDataSeeder.Seed(serviceProvider).Wait();

            return app;
        }
    }
}