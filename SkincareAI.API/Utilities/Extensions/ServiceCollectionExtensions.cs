using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SkincareAI.API.Data.Contexts;
using SkincareAI.API.Services.Interfaces;
using SkincareAI.API.Services.Implementations;
using SkincareAI.API.Data.Repositories;
using SkincareAI.API.Services.AI;
using SkincareAI.API.Utilities.Validators;
using SkincareAI.API.Models.Requests;

namespace SkincareAI.API.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSkincareServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseServices(configuration)
                    .AddApplicationServices()
                    .AddValidationServices()
                    .AddCorsServices();

            return services;
        }

        public static IServiceCollection AddValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<SkincareAnalysisRequestValidator>();
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register services
            services.AddScoped<ISkincareAnalysisService, SkincareAnalysisService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IUserHistoryService, UserHistoryService>();

            // Register repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserHistoryRepository, UserHistoryRepository>();

            // Register AI services
            services.AddScoped<ISymptomAnalyzer, MockSymptomAnalyzer>();
            services.AddScoped<ProductRecommender>();

            return services;
        }

        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SkincareDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}