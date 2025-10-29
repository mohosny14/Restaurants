using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    public UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository)
    {
        _restaurantsRepository = restaurantsRepository;
    }
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantsRepository.GetRestaurantById(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        // Update restaurant properties
        UpdateRestaurantCommand.MapUpdateRequestToRestaurant(restaurant, request);
        // Save changes
        await _restaurantsRepository.UpdateRestaurant(restaurant);
    }
}