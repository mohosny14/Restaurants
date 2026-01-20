using Restaurants.Domain.Entities;

namespace Restaurants.Domain.IRepositories;

public interface IDishesRepository
{
    Task<int> Create(Dish entity);
    public Task<IEnumerable<Dish>> GetByIdAsync(int restaurantId);
    public Task DeleteDishesForRestaurant(IEnumerable<Dish> dishes);
    // public Task<Restaurant> GetRestaurantById(int id);
}