using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    // Enumeracja reprezentująca operacje na zasobach
    public enum ResourceOperation
    {
        Create, // Tworzenie
        Update, // Aktualizacja
        Delete, // Usuwanie
        Read // Odczyt
    }

    // Klasa reprezentująca wymaganie operacji na zasobie
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        // Konstruktor przyjmujący typ operacji na zasobie jako argument
        public ResourceOperationRequirement(ResourceOperation resourceOperation)
        {
            // Ustawianie właściwości ResourceOperation na przekazany argument
            ResourceOperation = resourceOperation;
        }

        // Właściwość przechowująca typ operacji na zasobie
        public ResourceOperation ResourceOperation { get; }
    }
}
