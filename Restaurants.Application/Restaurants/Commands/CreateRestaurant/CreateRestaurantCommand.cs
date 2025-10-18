using MediatR;
using Restaurants.Application.Dtos.Dish;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; } = default!;
    public string ContactEmail { get; set; } = default!;
    public string ContactNumber { get; set; } = default!;
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public List<CreateDishDto> Dishes { get; set; } = [];

    public static Restaurant MapCreateDtoToRestaurant(CreateRestaurantCommand request)
    {
        return new Restaurant
        {
            Name = request.Name,
            Description = request.Description,
            Category = request.Category,
            HasDelivery = request.HasDelivery,
            Address = new Address
            {
                City = request.City,
                Street = request.Street,
                PostalCode = request.PostalCode
            },
            Dishes = request.Dishes.Select(DishDto.MapCreateDtoToDish).ToList()
        };
    }
}