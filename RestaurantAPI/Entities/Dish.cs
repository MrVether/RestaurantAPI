namespace RestaurantAPI.Entities
{
    public class Dish
    {
        //The unique ID of the dish
        public int Id { get; set; }

        //The name of the dish
        public string Name { get; set; }

        //The description of the dish
        public string Description { get; set; }

        //The price of the dish
        public decimal Price { get; set; }

        //The ID of the restaurant that the dish belongs to
        public int RestaurantId { get; set; }

        //Navigation property for related restaurant
        public virtual Restaurant Restaurant { get; set; }
    }
}
