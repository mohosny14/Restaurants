using Restaurants.Domain.Entities;

namespace Restaurants.Domain.IRepositories
{
    public interface IRestaurantsRepository
    {
        public Task<IEnumerable<Restaurant>> GetAllRestaurants();
        public Task<Restaurant> GetRestaurantById(int id);
        public Task<int> CreateRestaurant(Restaurant restaurant);
        public Task<bool> DeleteRestaurant(Restaurant restaurant);
        public Task<bool> UpdateRestaurant(Restaurant restaurant);
    }
}