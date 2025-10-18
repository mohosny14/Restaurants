using MediatR;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
{
    private readonly IRestaurantsRepository _restaurantsRepository;

    public CreateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository)
    {
        _restaurantsRepository = restaurantsRepository;
    }
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = CreateRestaurantCommand.MapCreateDtoToRestaurant(request);
        return await _restaurantsRepository.CreateRestaurant(restaurant);
    }
}