using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly ILogger<GetAllRestaurantsQueryHandler> _logger;
    public GetAllRestaurantsQueryHandler(IRestaurantsRepository restaurantsRepository, ILogger<GetAllRestaurantsQueryHandler> logger)
    {
        _restaurantsRepository = restaurantsRepository;
        _logger = logger;
    }
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting All Restaurants...");
        var restaurants = await _restaurantsRepository.GetAllRestaurants();

        var restaurantDtos = restaurants.Select(RestaurantDto.MapRestaurantToDto).ToList();

        if (!restaurantDtos.Any())
        {
            _logger.LogWarning("No restaurants found.");
            throw new NotFoundException(nameof(Restaurant), "All");
        }
        return restaurantDtos!;
    }
}