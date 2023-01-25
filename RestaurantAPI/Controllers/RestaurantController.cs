﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Collections.Generic;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize()]
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
            _restaurantService.Delete(id);


            return NoContent();

        }

        //Creates a new restaurant from data passed in request body and returns created with location of new resource or bad request if data is invalid
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {

            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }

        //Returns all restaurants
        [HttpGet]
        [Authorize(Policy = "Atleast20")]
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

            return Ok(restaurant);
        }

        //Updates a restaurant by ID and returns OK if successful or not found if not found or bad request if data is invalid
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {

            _restaurantService.Update(id, dto);

            return Ok();
        }
    }
}