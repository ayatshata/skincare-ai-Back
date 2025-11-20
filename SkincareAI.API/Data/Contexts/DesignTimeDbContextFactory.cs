using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SkincareAI.API.Data.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SkincareDbContext>
    {
        public SkincareDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SkincareDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SkincareAI;Trusted_Connection=true;TrustServerCertificate=true;");

            return new SkincareDbContext(optionsBuilder.Options);
        }
    }
}