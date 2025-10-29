using MediatR;
using Restaurants.Application.Dtos.Dish;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public string Category { get; set; }
    public bool HasDelivery { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public List<CreateDishDto>? Dishes { get; set; } = [];

    public static Restaurant MapUpdateDtoToRestaurantWithNew(UpdateRestaurantCommand request)
    {
        return new Restaurant
        {
            Id = request.Id,
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

    public static void MapUpdateRequestToRestaurant(Restaurant restaurant,UpdateRestaurantCommand request)
    {
        restaurant.Name = request.Name;
        restaurant.Description = request.Description;
        restaurant.Category = request.Category;
        restaurant.HasDelivery = request.HasDelivery;
        restaurant.ContactEmail = request.ContactEmail;
        restaurant.ContactNumber = request.ContactNumber;
        restaurant.Address ??= new Address();
        restaurant.Address.City = request.City;
        restaurant.Address.Street = request.Street;
        restaurant.Address.PostalCode = request.PostalCode;
        // Updating Dishes is more complex and may require additional logic
        if(request.Dishes != null)
        {
            foreach (var dishDto in request.Dishes)
            {
                var existingDish = restaurant.Dishes.FirstOrDefault(d => d.Name == dishDto.Name);
                if (existingDish != null)
                {
                    // Update existing dish
                    existingDish.Description = dishDto.Description;
                    existingDish.Price = dishDto.Price;
                    existingDish.KiloCalories = dishDto.KiloCalories;
                }
                else
                {
                    // Add new dish
                    restaurant.Dishes.Add(DishDto.MapCreateDtoToDish(dishDto));
                }
            }
        }
       // return restaurant;
    }
}