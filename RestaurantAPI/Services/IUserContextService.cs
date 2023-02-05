using System.Security.Claims;

namespace RestaurantAPI.Services
{
    public interface IUserContextService
    {
        int? GetUserId { get; }
        ClaimsPrincipal User { get; }
    }
}