using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Collections.Generic;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]

    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            //Tworzenie nowego restauracji
            var id = _restaurantService.Create(dto);

            //Zwracanie informacji o utworzeniu restauracji
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            //Pobieranie wszystkich restauracji
            var restaurantsDtos = _restaurantService.GetAll();

            //Zwracanie wszystkich restauracji
            return Ok(restaurantsDtos);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {
            //Aktualizacja restauracji o danym ID
            _restaurantService.Update(id, dto);

            //Zwracanie informacji o pomyślnej aktualizacji
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Usuwanie restauracji o danym ID
            _restaurantService.Delete(id);

            //Zwracanie informacji o pomyślnym usunięciu
            return NoContent();
        }



        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            //Pobieranie restauracji o danym ID
            var restaurant = _restaurantService.GetById(id);

            //Zwracanie restauracji o danym ID
            return Ok(restaurant);
        }
    }
}
