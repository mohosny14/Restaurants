using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Commands.UploadRestaurantLogos;
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

            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto?>> GetById([FromRoute] int id)
        {
            var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));

            return Ok(restaurant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            await _mediator.Send(new DeleteRestaurantCommand(id));
            return NoContent();
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
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/logo")]
        public async Task<IActionResult> UploadLogo(int id, IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var command = new UploadRestaurantLogoCommand()
            {
                RestaurantId = id,
                FileName = file.FileName,
                File = stream,
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}