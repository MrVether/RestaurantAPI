namespace RestaurantAPI.Entities
{
    public class Address
    {
        //The unique ID of the address
        public int Id { get; set; }

        //The city of the address
        public string City { get; set; }

        //The street of the address
        public string Street { get; set; }

        //The postal code of the address
        public string PostalCode { get; set; }

        //Navigation property for related restaurant
        public virtual Restaurant Restaurant { get; set; }
    }
}
