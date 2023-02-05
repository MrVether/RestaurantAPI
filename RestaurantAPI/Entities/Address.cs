namespace RestaurantAPI.Entities
{
    public class Address
    {
        //Unikalne ID adresu
        public int Id { get; set; }

        //Miasto adresu
        public string City { get; set; }

        //Ulica adresu
        public string Street { get; set; }

        //Kod pocztowy adresu
        public string PostalCode { get; set; }

        //Właściwość nawigacji dla powiązanego restauracji
        public virtual Restaurant Restaurant { get; set; }
    }
}
