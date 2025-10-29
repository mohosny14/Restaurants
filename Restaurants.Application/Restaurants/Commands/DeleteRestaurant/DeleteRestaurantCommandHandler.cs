using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    public DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository)
    {
        _restaurantsRepository = restaurantsRepository;
    }
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantsRepository.GetRestaurantById(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        await _restaurantsRepository.DeleteRestaurant(restaurant);
    }
}