using MediatR;
using Restaurants.Application.Restaurants.Commands.Dtos.Restaurants;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}