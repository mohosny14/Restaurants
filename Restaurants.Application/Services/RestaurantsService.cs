using Microsoft.Extensions.Logging;
using Restaurants.Application.IServices;
using Restaurants.Domain.Entities;
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
        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            _logger.LogInformation("Getting All Restaurants...");
            var restaurants = await _restaurantsRepository.GetAllRestaurants();
            return restaurants;
        }

        public async Task<Restaurant> GetRestaurantById()
        {
           var restaurant = await _restaurantsRepository.GetRestaurantById();
              return restaurant;
        }
    }
}