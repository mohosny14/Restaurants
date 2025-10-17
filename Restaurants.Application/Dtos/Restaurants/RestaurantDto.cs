using Restaurants.Application.Dtos.Restaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; } = default!;
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public List<DishDto> Dishes { get; set; } = [];

    public static RestaurantDto? MapRestaurantToDto(Restaurant? restaurant)
    {
        if (restaurant == null) return null;

        return new RestaurantDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Category = restaurant.Category,
            HasDelivery = restaurant.HasDelivery,
            City = restaurant.Address?.City,
            Street = restaurant.Address?.Street,
            PostalCode = restaurant.Address?.PostalCode,
            Dishes = restaurant.Dishes.Select(DishDto.MapDishToDto).ToList()
        };
    }

    public static Restaurant MapCreateDtoToRestaurant(CreateRestaurantDto createRestaurantDto)
    {
        return new Restaurant
        {
            Name = createRestaurantDto.Name,
            Description = createRestaurantDto.Description,
            Category = createRestaurantDto.Category,
            HasDelivery = createRestaurantDto.HasDelivery,
            Address = new Address
            {
                City = createRestaurantDto.City,
                Street = createRestaurantDto.Street,
                PostalCode = createRestaurantDto.PostalCode
            },
            Dishes = createRestaurantDto.Dishes.Select(DishDto.MapCreateDtoToDish).ToList()
        };
    }
}