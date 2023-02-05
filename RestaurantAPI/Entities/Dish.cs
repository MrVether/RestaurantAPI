namespace RestaurantAPI.Entities
{
    public class Dish
    {
        //Unikalne ID dania
        public int Id { get; set; }

        //Nazwa dania
        public string Name { get; set; }

        //Opis dania
        public string Description { get; set; }

        //Cena dania
        public decimal Price { get; set; }

        //ID restauracji, do której danie należy
        public int RestaurantId { get; set; }

        //Właściwość nawigacji do powiązanej restauracji
        public virtual Restaurant Restaurant { get; set; }
    }
}
