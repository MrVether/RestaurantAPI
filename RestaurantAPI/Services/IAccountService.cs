using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IAccountService
    {
        string GenerateJwt(LoginDto dto);
        void RegisterUser(RegisterUserDto dto);
    }
}
