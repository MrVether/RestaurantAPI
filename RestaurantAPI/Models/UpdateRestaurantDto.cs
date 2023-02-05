using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class UpdateRestaurantDto
    {
        //Name of the restaurant, required and max length of 25
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        //Description of the restaurant
        public string Description { get; set; }

        //Indicates if the restaurant has delivery service
        public bool HasDelivery { get; set; }
    }
}
