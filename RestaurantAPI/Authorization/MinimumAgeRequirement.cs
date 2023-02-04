using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    // Klasa reprezentująca wymaganie minimalnego wieku
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        // Minimalny wiek
        public int MinimumAge { get; }

        // Konstruktor przyjmujący minimalny wiek
        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
}