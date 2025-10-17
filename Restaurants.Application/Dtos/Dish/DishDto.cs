using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dtos
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }
        public static DishDto MapDishToDto(Dish restaurant)
        {
            return new DishDto
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Price = restaurant.Price,
                KiloCalories = restaurant.KiloCalories
            };
        }
    }
}