using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }
        [HttpDelete]
        public ActionResult Delete([FromRoute] int restaurantId)
        {
            _dishService.RemoveAll(restaurantId);
            return NoContent();
        }
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, CreateDishDto dto)
        {
            var newDishId = _dishService.Create(restaurantId, dto);
            return Created($"api/restaurant/{restaurantId}/dish/{newDishId}", null);
        }
        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get(int RestaurantId, [FromRoute] int dishId)
        {
            var dish = _dishService.GetById(RestaurantId, dishId);
            return Ok(dish);

        }
        [HttpGet]
        public ActionResult<DishDto> Get(int RestaurantId)
        {
            var result = _dishService.GetAll(RestaurantId);
            return Ok(result);

        }
    }
}
