using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        //Creates a new restaurant and returns the id
        int Create(CreateRestaurantDto dto);

        //Gets all restaurants
        IEnumerable<RestaurantDto> GetAll();

        //Gets a restaurant by id
        RestaurantDto GetById(int id);

        //Deletes a restaurant by id and returns a boolean indicating if the operation was successful
        void Delete(int id);

        //Updates a restaurant by id and returns a boolean indicating if the operation was successful
        void Update(int id, UpdateRestaurantDto dto);
    }
}
