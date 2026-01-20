using MediatR;
using Restaurants.Application.Restaurants.Commands.Dtos.Restaurants;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto>
{
    public int Id { get; set; } = id;
}