using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantAPI.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Restaurant>
    {
        // Ta metoda jest wywoływana przez system uwierzytelniania i autoryzacji w aplikacji ASP.NET Core, aby określić, czy użytkownik może uzyskać dostęp do zasobu.
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Restaurant restaurant)
        {
            // Jeśli wymagana operacja na zasobie to 'Read' lub 'Create', to uwierzytelnienie powiedzie się.
            if (requirement.ResourceOperation == ResourceOperation.Read || requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            // Pobierz identyfikator użytkownika z jego twierdzenia.
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            // Jeśli identyfikator twórcy restauracji jest taki sam jak identyfikator użytkownika, uwierzytelnienie powiedzie się.
            if (restaurant.CreatedById == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            // Zakończ wykonanie metody.
            return Task.CompletedTask;
        }
    }
}
