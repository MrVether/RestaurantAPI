using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        //DbContext for the database
        private readonly RestaurantDbContext _dbContext;
        //Automapper for mapping between DTOs and entities
        private readonly IMapper _mapper;

        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }

        //Updates a restaurant based on id and the data in the UpdateRestaurantDto
        public bool Update(int id, UpdateRestaurantDto dto)
        {
            var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(r => r.Id == id);
            if (restaurant is null)
            {
                return false;
                //if the restaurant is not found, return false
            }
            //update the properties
            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.HasDelivery = dto.HasDelivery;
            _dbContext.SaveChanges();
            return true;

        }
        //Delete a restaurant by id.
        public bool Delete(int id)
        {
            var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(r => r.Id == id);
            if (restaurant is null) return false;

            _dbContext.Restaurants.Remove(restaurant);
            _dbContext.SaveChanges();
            return true;
        }
        // Get a restaurant by id
        public RestaurantDto GetById(int id)
        {
            var restaurant = _dbContext
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == id);
            if (restaurant == null) { return null; }
            var result = _mapper.Map<RestaurantDto>(restaurant);
            return result;
        }
        // Get all the restaurants
        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }

        // Create a restaurant
        public int Create(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant.Id;
        }
    }
}
