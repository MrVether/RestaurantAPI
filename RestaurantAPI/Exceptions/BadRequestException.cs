//Klasa wyjątku obsługującego błędy w żądaniach HTTP 400 Bad Request
using System;

namespace RestaurantAPI.Exceptions
{
    public class BadRequestException : Exception
    {
        //Konstruktor, który przyjmuje wiadomość jako argument i przekazuje ją do klasy bazowej (klasy Exception)
        public BadRequestException(string message) : base(message)
        {


        }
    }
}