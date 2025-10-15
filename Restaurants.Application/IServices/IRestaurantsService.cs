using Restaurants.Domain.Entities;

namespace Restaurants.Application.IServices
{
    public interface IRestaurantsService
    {
        public Task<IEnumerable<Restaurant>> GetAllRestaurants();
        public Task<Restaurant> GetRestaurantById();
    }
}
