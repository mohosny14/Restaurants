using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Application.IServices;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Services
{
    public class RestaurantsService : IRestaurantsService
    {
        private readonly IRestaurantsRepository _restaurantsRepository;
        private readonly ILogger<RestaurantsService> _logger;

        public RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger)
        {
            _restaurantsRepository = restaurantsRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            _logger.LogInformation("Getting All Restaurants...");
            var restaurants = await _restaurantsRepository.GetAllRestaurants();

            var restaurantDtos = restaurants.Select(RestaurantDto.MapRestaurantToDto).ToList();

            if (!restaurantDtos.Any())
            {
                _logger.LogWarning("No restaurants found.");
            }
            return restaurantDtos!;
        }
        public async Task<RestaurantDto> GetRestaurantById()
        {
            var restaurant = await _restaurantsRepository.GetRestaurantById();
            var restaurantDto = RestaurantDto.MapRestaurantToDto(restaurant);
            return restaurantDto!;
        }
    }
}