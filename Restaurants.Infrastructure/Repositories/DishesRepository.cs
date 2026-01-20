using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class DishesRepository : IDishesRepository
{
    private readonly RestaurantsDbContext _dbContext;
    public DishesRepository(RestaurantsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Create(Dish entity)
    {
        await _dbContext.Dishes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Dish>> GetByIdAsync(int restaurantId)
    {
        var dishes = await _dbContext.Dishes.Where(d => d.RestaurantId == restaurantId)
                .ToListAsync();

        return dishes;
    }

    public async Task DeleteDishesForRestaurant(IEnumerable<Dish> dishes)
    {
        _dbContext.Dishes.RemoveRange(dishes);
        await _dbContext.SaveChangesAsync();
    }
}