using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Collections.Generic;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        //A service to handle restaurant data
        private readonly IRestaurantService _restaurantService;

        //Injecting service 
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        //Deletes a restaurant by ID and returns no content if successful or not found if not
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _restaurantService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        //Creates a new restaurant from data passed in request body and returns created with location of new resource or bad request if data is invalid
        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }

        //Returns all restaurants
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDtos = _restaurantService.GetAll();
            return Ok(restaurantsDtos);
        }

        //Returns a restaurant by ID or not found if not found
        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        //Updates a restaurant by ID and returns OK if successful or not found if not found or bad request if data is invalid
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isUpdated = _restaurantService.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}