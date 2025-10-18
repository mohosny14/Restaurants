using MediatR;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    public GetRestaurantByIdQueryHandler(IRestaurantsRepository restaurantsRepository)
    {
        _restaurantsRepository = restaurantsRepository;
    }
    public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantsRepository.GetRestaurantById(request.Id);
        var restaurantDto = RestaurantDto.MapRestaurantToDto(restaurant);
        return restaurantDto!;
    }
}