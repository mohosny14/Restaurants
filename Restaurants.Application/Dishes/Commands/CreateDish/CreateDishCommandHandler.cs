using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Authorization.Services;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger, IRestaurantAuthorizationService restaurantAuthorizationService,
    IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository) : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Create new dish: {@DishRequest}", request);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, Domain.ResourceOperation.Create))
            throw new ForbidException();

        var dish = CreateDishCommand.MapCreateDishCommandToDish(request);
        return await dishesRepository.Create(dish);
    }
}