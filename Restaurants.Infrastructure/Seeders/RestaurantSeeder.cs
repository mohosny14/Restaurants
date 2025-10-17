using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders
{
    public class RestaurantSeeder(RestaurantsDbContext context) : IRestaurantSeeder
    {
        public async Task SeedAsync()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Restaurants.Any())
                {
                    var restaurants = GetResaurants();
                    context.Restaurants.AddRange(restaurants);
                    await context.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Restaurant> GetResaurants()
        {
            return new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Italian Bistro",
                    Category = "Italian",
                    Description = "Cozy place for authentic Italian cuisine.",
                    HasDelivery = true,
                    ContactEmail = "mo@mo.com",
                    Address = new Address
                    {
                        City = "New York",
                        Street = "123 Pasta",
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Spaghetti Carbonara", Price = 12.99m, Description= "Classic Roman pasta with eggs, cheese, pancetta." },
                        new Dish { Name = "Margherita Pizza", Price = 10.99m, Description = "Traditional pizza with tomato, mozzarella, and basil." }
                    },
                },
                new Restaurant
                {
                    Name = "Sushi House",
                    Category = "Japanese",
                    Description = "Fresh sushi and sashimi prepared by expert chefs.",
                    HasDelivery = false,
                    ContactEmail = "info@sushihouse.com",
                    Address = new Address
                    {
                        City = "San Francisco",
                        Street = "456 Sashimi Ave",
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Salmon Nigiri", Price = 4.99m, Description = "Sliced salmon over rice." },
                        new Dish { Name = "California Roll", Price = 7.99m, Description = "Crab, avocado, and cucumber roll." }
                    },
                },
                new Restaurant
                {
                    Name = "Burger Joint",
                    Category = "American",
                    Description = "Classic and gourmet burgers with a variety of sides.",
                    HasDelivery = true,
                    ContactEmail = "contact@burgerjoint.com",
                    Address = new Address
                    {
                        City = "Chicago",
                        Street = "789 Burger Blvd",
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Cheeseburger", Price = 8.99m, Description = "Beef patty with cheddar cheese, lettuce, and tomato." },
                        new Dish { Name = "Veggie Burger", Price = 9.49m, Description = "Grilled vegetable patty with fresh toppings." }
                    },
                },
                new Restaurant
                {
                    Name = "Taco Fiesta",
                    Category = "Mexican",
                    Description = "Authentic Mexican tacos and street food.",
                    HasDelivery = false,
                    ContactEmail = "hello@tacofiesta.com",
                    Address = new Address
                    {
                        City = "Los Angeles",
                        Street = "321 Taco St",
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Chicken Tacos", Price = 6.99m, Description = "Soft tortillas filled with seasoned chicken." },
                        new Dish { Name = "Beef Quesadilla", Price = 7.99m, Description = "Grilled tortilla stuffed with beef and cheese." }
                    },
                },
                new Restaurant
                {
                    Name = "Curry Palace",
                    Category = "Indian",
                    Description = "Rich and flavorful Indian curries and breads.",
                    HasDelivery = true,
                    ContactEmail = "order@currypalace.com",
                    Address = new Address
                    {
                        City = "Houston",
                        Street = "654 Curry",
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Butter Chicken", Price = 13.99m, Description = "Creamy tomato-based chicken curry." },
                        new Dish { Name = "Paneer Tikka Masala", Price = 12.49m, Description = "Grilled paneer in spicy masala sauce." }
                    },
                }
            };
        }
    }
}