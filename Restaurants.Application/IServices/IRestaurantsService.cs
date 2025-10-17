using Restaurants.Application.Dtos;
using Restaurants.Application.Dtos.Restaurant;

namespace Restaurants.Application.IServices
{
    public interface IRestaurantsService
    {
        public Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        public Task<RestaurantDto> GetRestaurantById();
        public Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto);
    }
}
