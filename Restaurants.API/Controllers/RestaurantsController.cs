using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
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
            if (restaurants == null) {
                return NotFound();
            }
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));
            if (restaurant == null) {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody]CreateRestaurantCommand command)
        {
            int id = await _mediator.Send(command);
            if (id == 0) {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = 0 }, null);
        }
    }
}