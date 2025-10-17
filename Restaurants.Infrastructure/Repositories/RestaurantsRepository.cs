using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    public class RestaurantsRepository : IRestaurantsRepository
    {
        private readonly RestaurantsDbContext _dbContext;
        public RestaurantsRepository(RestaurantsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            var restaurants = await _dbContext.Restaurants
                //.Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToListAsync();

            return restaurants;
        }

        public async Task<Restaurant> GetRestaurantById()
        {
            var restaurant = await _dbContext.Restaurants
                //.Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync();
            return restaurant!;
        }
    }
}