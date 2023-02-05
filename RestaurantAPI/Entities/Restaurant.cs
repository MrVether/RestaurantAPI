using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public class Restaurant
    {
        //Unikalne ID restauracji
        public int Id { get; set; }

        //Nazwa restauracji
        public string Name { get; set; }

        //Opis restauracji
        public string Description { get; set; }

        //Kategoria restauracji
        public string Category { get; set; }

        //Informacja czy restauracja ma usługę dostawy
        public bool HasDelivery { get; set; }

        //Kontaktowy adres e-mail restauracji
        public string ContactEmail { get; set; }

        //Kontaktowy numer telefonu restauracji
        public string ContactNumber { get; set; }

        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

        //ID adresu, do którego należy restauracja
        public int AddressId { get; set; }

        //Właściwość nawigacyjna dla powiązanego adresu
        public virtual Address Address { get; set; }

        //Właściwość nawigacyjna dla powiązanych dań
        public virtual List<Dish> Dishes { get; set; }
    }
}
