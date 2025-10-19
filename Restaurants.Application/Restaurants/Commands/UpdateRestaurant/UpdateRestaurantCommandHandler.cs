using MediatR;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, bool>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    public UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository)
    {
        _restaurantsRepository = restaurantsRepository;
    }
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantsRepository.GetRestaurantById(request.Id);
        if (restaurant == null)
            return false;

        // Update restaurant properties
        UpdateRestaurantCommand.MapUpdateRequestToRestaurant(restaurant, request);
        // Save changes
        var result = await _restaurantsRepository.UpdateRestaurant(restaurant);
        return result;
    }
}