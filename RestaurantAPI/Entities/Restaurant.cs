using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public class Restaurant
    {
        //The unique ID of the restaurant
        public int Id { get; set; }

        //The name of the restaurant
        public string Name { get; set; }

        //The description of the restaurant
        public string Description { get; set; }

        //The category of the restaurant
        public string Category { get; set; }

        //Indicates if the restaurant has delivery service
        public bool HasDelivery { get; set; }

        //The contact email of the restaurant
        public string ContactEmail { get; set; }

        //The contact number of the restaurant
        public string ContactNumber { get; set; }

        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

        //The ID of the address that the restaurant belongs to
        public int AddressId { get; set; }

        //Navigation property for related address
        public virtual Address Address { get; set; }

        //Navigation property for related dishes
        public virtual List<Dish> Dishes { get; set; }
    }
}
