using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _mediator.Send(new GetAllRestaurantsQuery());
            if (restaurants == null)
            {
                return NotFound();
            }
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto?>> GetById([FromRoute] int id)
        {
            var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));
            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            var isDeleted = await _mediator.Send(new DeleteRestaurantCommand(id));
            if (isDeleted)
                return NoContent();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            int id = await _mediator.Send(command);
            if (id == 0)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = 0 }, null);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateRestaurant([FromBody] UpdateRestaurantCommand command)
        {
            var isDeleted = await _mediator.Send(command);
            if (isDeleted)
                return NoContent();

            return NotFound();
        }
    }
}