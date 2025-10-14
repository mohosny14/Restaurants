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
                    Descritpion = "Cozy place for authentic Italian cuisine.",
                    HasDelivery = true,
                    ContactEmail = "mo@mo.com",
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Spaghetti Carbonara", Price = 12.99m, Descritpion = "Classic Roman pasta with eggs, cheese, pancetta." },
                        new Dish { Name = "Margherita Pizza", Price = 10.99m, Descritpion = "Traditional pizza with tomato, mozzarella, and basil." }
                    },
                },
                new Restaurant
                {
                    Name = "Sushi House",
                    Category = "Japanese",
                    Descritpion = "Fresh sushi and sashimi prepared by expert chefs.",
                    HasDelivery = false,
                    ContactEmail = "info@sushihouse.com",
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Salmon Nigiri", Price = 4.99m, Descritpion = "Sliced salmon over rice." },
                        new Dish { Name = "California Roll", Price = 7.99m, Descritpion = "Crab, avocado, and cucumber roll." }
                    },
                },
                new Restaurant
                {
                    Name = "Burger Joint",
                    Category = "American",
                    Descritpion = "Classic and gourmet burgers with a variety of sides.",
                    HasDelivery = true,
                    ContactEmail = "contact@burgerjoint.com",
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Cheeseburger", Price = 8.99m, Descritpion = "Beef patty with cheddar cheese, lettuce, and tomato." },
                        new Dish { Name = "Veggie Burger", Price = 9.49m, Descritpion = "Grilled vegetable patty with fresh toppings." }
                    },
                },
                new Restaurant
                {
                    Name = "Taco Fiesta",
                    Category = "Mexican",
                    Descritpion = "Authentic Mexican tacos and street food.",
                    HasDelivery = false,
                    ContactEmail = "hello@tacofiesta.com",
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Chicken Tacos", Price = 6.99m, Descritpion = "Soft tortillas filled with seasoned chicken." },
                        new Dish { Name = "Beef Quesadilla", Price = 7.99m, Descritpion = "Grilled tortilla stuffed with beef and cheese." }
                    },
                },
                new Restaurant
                {
                    Name = "Curry Palace",
                    Category = "Indian",
                    Descritpion = "Rich and flavorful Indian curries and breads.",
                    HasDelivery = true,
                    ContactEmail = "order@currypalace.com",
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Butter Chicken", Price = 13.99m, Descritpion = "Creamy tomato-based chicken curry." },
                        new Dish { Name = "Paneer Tikka Masala", Price = 12.49m, Descritpion = "Grilled paneer in spicy masala sauce." }
                    },
                }
            };
        }
    }
}