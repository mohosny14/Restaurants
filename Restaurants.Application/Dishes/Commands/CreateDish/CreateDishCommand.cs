using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int? KiloCalories { get; set; }
    public int RestaurantId { get; set; }

    public static Dish MapCreateDishCommandToDish(CreateDishCommand dto)
    {
        return new Dish
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            KiloCalories = dto.KiloCalories,
            RestaurantId = dto.RestaurantId
        };
    }
}