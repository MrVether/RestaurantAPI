using System;

namespace RestaurantAPI.Entities
{
    public class User
    {
        //Id użytkownika
        public int Id { get; set; }
        //Adres email użytkownika
        public string Email { get; set; }

        //Data urodzenia użytkownika
        public DateTime? DateOfBirth { get; set; }

        //Narodowość użytkownika
        public string Nationality { get; set; }

        //Hash hasła użytkownika
        public string PasswordHash { get; set; }

        //Id roli, którą użytkownik pełni
        public int RoleId { get; set; }

        //Wirtualna właściwość reprezentująca rolę użytkownika
        public virtual Role Role { get; set; }
    }

}

