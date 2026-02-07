using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Authorization.Services;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService)
    : IRequestHandler<UpdateRestaurantCommand>
{
    private readonly IRestaurantsRepository _restaurantsRepository = restaurantsRepository;

    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantsRepository.GetRestaurantById(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, Domain.ResourceOperation.Update))
            throw new ForbidException();

        // Update restaurant properties
        UpdateRestaurantCommand.MapUpdateRequestToRestaurant(restaurant, request);
        // Save changes
        await _restaurantsRepository.UpdateRestaurant(restaurant);
        await _restaurantsRepository.SaveChanges();
    }
}