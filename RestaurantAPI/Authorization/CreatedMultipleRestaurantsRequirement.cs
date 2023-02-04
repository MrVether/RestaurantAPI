using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    // Klasa implementująca wymaganie autoryzacji użytkownika do tworzenia wielu restauracji
    public class CreatedMultipleRestaurantsRequirement : IAuthorizationRequirement
    {
        // Konstruktor przyjmujący minimalną liczbę restauracji, którą użytkownik musi utworzyć, aby być autoryzowanym
        public CreatedMultipleRestaurantsRequirement(int minimumRestaurantsCreated)
        {
            // Przypisywanie wartości do właściwości MinimumRestaurantCreated
            MinimumRestaurantCreated = minimumRestaurantsCreated;
        }

        // Właściwość zawierająca minimalną liczbę restauracji, którą użytkownik musi utworzyć, aby być autoryzowanym
        public int MinimumRestaurantCreated { get; }
    }
}
