using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class CreateRestaurantDto
    {
        //Name of the restaurant, required and max length of 25
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        //Description of the restaurant
        public string Description { get; set; }

        //Category of the restaurant
        public string Category { get; set; }

        //Indicates if the restaurant has delivery service
        public bool HasDelivery { get; set; }

        //Contact email of the restaurant
        public string ContactEmail { get; set; }

        //Contact number of the restaurant
        public string ContactNumber { get; set; }

        //City of the restaurant address, required and max length of 50
        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        //Street of the restaurant address, required and max length of 50
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        //Postal code of the restaurant address
        public string PostalCode { get; set; }
    }
}
