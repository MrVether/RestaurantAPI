using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/account")] // Zadeklarowanie, że ścieżka dostępu do kontrolera to "api/account".
    [ApiController] // Oznaczenie, że jest to kontroler API.
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService; // Deklaracja zmiennej _accountService typu IAccountService.

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")] // Zadeklarowanie, że akcja jest odpowiedzialna za rejestrację użytkownika i dostępna przez ścieżkę "api/account/register"
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto); // Wywołanie metody RegisterUser na obiekcie _accountService i przekazanie argumentu dto.
            return Ok(); // Zwrócenie wyniku 200 OK.
        }

        [HttpPost("login")] // Zadeklarowanie, że akcja jest odpowiedzialna za logowanie użytkownika i dostępna przez ścieżkę "api/account/login"
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto); // Wywołanie metody GenerateJwt na obiekcie _accountService i przekazanie argumentu dto.
            HttpContext.Response.Headers.Add("Authorization", $"Bearer {token}");
            return Ok(token); // Zwrócenie wyniku 200 OK z wartością token.

        }
    }
}
