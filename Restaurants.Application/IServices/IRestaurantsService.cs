using Restaurants.Application.Dtos;

namespace Restaurants.Application.IServices
{
    public interface IRestaurantsService
    {
        public Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        public Task<RestaurantDto> GetRestaurantById();
    }
}
