using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantAPI.Authorization
{
    // Klasa reprezentująca handler dla wymagania minimalnego wieku
    public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        // Logger
        private readonly ILogger<MinimumAgeRequirement> _logger;

        // Konstruktor przyjmujący logger
        public MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirement> logger)
        {
            _logger = logger;
        }

        // Metoda odpowiadająca za sprawdzenie, czy użytkownik spełnia wymagania minimalnego wieku
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            // Pobieranie daty urodzenia użytkownika z jego Claims
            var dateOfBirth = DateTime.Parse(context.User.FindFirst(c => c.Type == "DateOfBirth").Value);
            // Pobieranie adresu email użytkownika
            var userEmail = context.User.FindFirst(c => c.Type == ClaimTypes.Name).Value;

            // Logowanie informacji o użytkowniku i jego dacie urodzenia
            _logger.LogInformation($"Użytkownik: {userEmail} z datą urodzenia: [{dateOfBirth}]");

            // Sprawdzenie, czy użytkownik jest wieku minimalnego
            if (dateOfBirth.AddYears(requirement.MinimumAge) <= DateTime.Today)
            {
                // Logowanie informacji o pomyślnej autoryzacji
                _logger.LogInformation("Autoryzacja udana");
                // Zatwierdzenie wymagania
                context.Succeed(requirement);
            }
            else
            {
                // Logowanie informacji o nieudanej autoryzacji
                _logger.LogInformation("Autoryzacja nieudana");
            }
            // Zakończenie procesu autoryzacji
            return Task.CompletedTask;

        }
    }
}
