namespace RestaurantAPI.Models
{
    public class DishDto
    {
        //Id of the dish
        public int Id { get; set; }

        //Name of the dish
        public string Name { get; set; }

        //Description of the dish
        public string Description { get; set; }

        //Price of the dish
        public decimal Price { get; set; }
    }
}
