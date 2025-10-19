using MediatR;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, bool>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    public DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository)
    {
        _restaurantsRepository = restaurantsRepository;
    }
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        return await _restaurantsRepository.DeleteRestaurant(request.Id);
    }
}