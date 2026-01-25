using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.Dtos.Restaurants;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDishesForRestaurant([FromRoute] int restaurantId)
    {
        // Implementation to get all dishes for a specific restaurant
        var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
        return Ok(dishes);
    }
    // TODO:
    [HttpGet]
    public async Task<IActionResult> GetDishByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        // Implementation to get all dishes for a specific restaurant
        var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDishForRestaurant([FromRoute] int restaurantId, CreateDishCommand command)
    {
        // Implementation to create a new dish for a specific restaurant
        command.RestaurantId = restaurantId;
        var dishId = await mediator.Send(command);

        return CreatedAtAction(nameof(GetDishesForRestaurant), new { restaurantId, dishId }, null);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDishesForRestaurant([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteRestaurantCommand(restaurantId));
        return NoContent();
    }
}