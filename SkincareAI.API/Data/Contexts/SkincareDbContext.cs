using Microsoft.EntityFrameworkCore;
using SkincareAI.API.Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SkincareAI.API.Data.Contexts
{
    public class SkincareDbContext : DbContext
    {
        public SkincareDbContext(DbContextOptions<SkincareDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

      
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Brand).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Price).HasPrecision(18, 2);

              
                entity.Property(p => p.Ingredients)
                    .HasConversion(
                        v => string.Join(';', v),
                        v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

                entity.Property(p => p.SuitableForSkinTypes)
                    .HasConversion(
                        v => string.Join(';', v),
                        v => v.Split(';', StringSplitOptions.RemoveEmptyEntries)
                              .Select(Enum.Parse<SkinType>).ToList());

                entity.Property(p => p.Benefits)
                    .HasConversion(
                        v => string.Join(';', v),
                        v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());
            });

            // UserHistory configuration
            modelBuilder.Entity<UserHistory>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.UserId).IsRequired().HasMaxLength(100);

                entity.Property(h => h.Concerns)
                    .HasConversion(
                        v => string.Join(';', v),
                        v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

                entity.Property(h => h.Symptoms)
                    .HasConversion(
                        v => string.Join(';', v),
                        v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

                entity.Property(h => h.RecommendedProductIds)
                    .HasConversion(
                        v => string.Join(';', v),
                        v => v.Split(';', StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse).ToList());
            });
        }
    }
}