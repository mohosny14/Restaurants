using MediatR;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}