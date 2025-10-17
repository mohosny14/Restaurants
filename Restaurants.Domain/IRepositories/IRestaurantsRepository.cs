using Restaurants.Domain.Entities;

namespace Restaurants.Domain.IRepositories
{
    public interface IRestaurantsRepository
    {
        public Task<IEnumerable<Restaurant>> GetAllRestaurants();
        public Task<Restaurant> GetRestaurantById();
        public Task<int> CreateRestaurant(Restaurant restaurant);
    }
}