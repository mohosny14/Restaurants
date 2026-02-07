using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Authorization.Services;

namespace Restaurants.Application.Dishes.Commands.DeleteDishesForRestaurant;

public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> _logger,
    IRestaurantsRepository _restaurantsRepository, IDishesRepository _dishesRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService)
    : IRequestHandler<DeleteDishesForRestaurantCommand>
{
    public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
    {
        _logger.LogWarning("Delete Dishes for restaurant ID: {@restaurntId}", request.RestaurantId);

        var restaurant = await _restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, Domain.ResourceOperation.Delete))
            throw new ForbidException();


        await _dishesRepository.DeleteDishesForRestaurant(restaurant.Dishes);

    }
}