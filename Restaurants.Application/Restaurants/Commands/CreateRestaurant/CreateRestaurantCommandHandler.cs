using MediatR;
using Restaurants.Application.Users;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
    IUserContext userContext) 
    : IRequestHandler<CreateRestaurantCommand, int>
{
    private readonly IRestaurantsRepository _restaurantsRepository = restaurantsRepository;

    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;

        var restaurant = CreateRestaurantCommand.MapCreateDtoToRestaurant(request);
        restaurant.OwnerId = currentUser.Id;
        return await _restaurantsRepository.CreateRestaurant(restaurant);
    }
}