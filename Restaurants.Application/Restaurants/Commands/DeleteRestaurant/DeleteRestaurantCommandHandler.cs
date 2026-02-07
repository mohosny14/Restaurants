using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Authorization.Services;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService) 
    : IRequestHandler<DeleteRestaurantCommand>
{
    private readonly IRestaurantsRepository _restaurantsRepository = restaurantsRepository;

    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantsRepository.GetRestaurantById(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());


        if (!restaurantAuthorizationService.Authorize(restaurant, Domain.ResourceOperation.Delete))
            throw new ForbidException();

        await _restaurantsRepository.DeleteRestaurant(restaurant);
    }
}