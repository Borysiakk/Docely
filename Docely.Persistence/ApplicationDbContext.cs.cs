using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Docely.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {

                IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

                string ConnectionStrings = configuration.GetConnectionString("ConnectionStrings");


                var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer();
                return new ApplicationDbContext(builder.Options);
            }
        }
    }
}