using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Restaurants.Infrastructure.Persistence
{
    public class RestaurantsDbContextFactory : IDesignTimeDbContextFactory<RestaurantsDbContext>
    {
        public RestaurantsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RestaurantsDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new RestaurantsDbContext(optionsBuilder.Options);
        }
    }
}