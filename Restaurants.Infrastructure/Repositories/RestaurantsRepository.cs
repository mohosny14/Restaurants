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

        public async Task<int> CreateRestaurant(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            await _dbContext.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            var restaurants = await _dbContext.Restaurants
                //.Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToListAsync();

            return restaurants;
        }

        public async Task<Restaurant> GetRestaurantById(int id)
        {
            var restaurant = await _dbContext.Restaurants
                //.Include(r => r.Address)
                .Where(r => r.Id == id)
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync();
            return restaurant!;
        }
        public async Task<bool> DeleteRestaurant(int id)
        {
            var restaurant = await _dbContext.Restaurants.FindAsync(id);
            if (restaurant == null)
                return false;
            _dbContext.Restaurants.Remove(restaurant);
            var isDeleted = await _dbContext.SaveChangesAsync();

            return isDeleted > 0;
        }

        public async Task<bool> UpdateRestaurant(Restaurant restaurant)
        {
            _dbContext.Restaurants.Update(restaurant);
            var isUpdated = await _dbContext.SaveChangesAsync();
            return isUpdated > 0;
        }
    }
}