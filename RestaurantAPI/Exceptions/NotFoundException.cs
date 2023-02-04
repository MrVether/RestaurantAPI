//Klasa NotFoundException jest wyjątkiem występującym, gdy dany element nie zostanie znaleziony

using System;

namespace RestaurantAPI.Exceptions
{
    public class NotFoundException : Exception
    {
        //Konstruktor, który przyjmuje wiadomość jako argument i przekazuje ją do klasy bazowej Exception
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
