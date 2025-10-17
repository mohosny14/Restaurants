using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dtos.Restaurant;
using Restaurants.Application.IServices;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantsService _restaurantsService;
        public RestaurantsController(IRestaurantsService restaurantsService)
        {
            _restaurantsService = restaurantsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _restaurantsService.GetAllRestaurants();
            if(restaurants == null) {
                return NotFound();
            }
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var restaurant = await _restaurantsService.GetRestaurantById();
            if(restaurant == null) {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody]CreateRestaurantDto createRestaurantDto)
        {
            int id = await _restaurantsService.CreateRestaurant(createRestaurantDto);
            if(id == 0) {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = 0 }, null);
        }
    }
}