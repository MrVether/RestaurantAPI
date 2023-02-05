using System.Collections.Generic;

namespace RestaurantAPI.Models
{
    public class RestaurantDto
    {
        //Id of the restaurant
        public int Id { get; set; }

        //Name of the restaurant
        public string Name { get; set; }

        //Description of the restaurant
        public string Description { get; set; }

        //Category of the restaurant
        public string Category { get; set; }

        //Indicates if the restaurant has delivery service
        public bool HasDelivery { get; set; }

        //City of the restaurant address
        public string City { get; set; }

        //Street of the restaurant address
        public string Street { get; set; }

        //Postal code of the restaurant address
        public string PostalCode { get; set; }

        //List of dishes of the restaurant
        public List<DishDto> Dishes { get; set; }
    }
}
