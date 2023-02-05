using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantAPI.Authorization
{
    // Klasa implementująca obsługę wymagania autoryzacji użytkownika do tworzenia wielu restauracji
    public class CreatedMultipleRestaurantsRequirementHandler : AuthorizationHandler<CreatedMultipleRestaurantsRequirement>
    {
        // Kontekst bazy danych
        private readonly RestaurantDbContext _context;

        // Konstruktor przyjmujący kontekst bazy danych
        public CreatedMultipleRestaurantsRequirementHandler(RestaurantDbContext context)
        {
            _context = context;
        }

        // Metoda asynchroniczna wywoływana w celu sprawdzenia, czy użytkownik spełnia wymaganie autoryzacji
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            CreatedMultipleRestaurantsRequirement requirement)
        {
            // Pobieranie ID użytkownika z claims
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            // Pobieranie liczby utworzonych przez użytkownika restauracji
            var createdRestaurantsCount = _context
                 .Restaurants
                 .Count(r => r.CreatedById == userId);

            // Jeśli użytkownik utworzył wymaganą liczbę restauracji, zwracane jest pozytywne wyniki
            if (createdRestaurantsCount >= requirement.MinimumRestaurantCreated)
            {
                context.Succeed(requirement);

            }
            return Task.CompletedTask;
        }
    }
}
