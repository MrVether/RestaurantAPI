using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/account")] // Zadeklarowanie, że ścieżka dostępu do kontrolera to "api/account".
    [ApiController] // Oznaczenie, że jest to kontroler API.
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService; // Deklaracja zmiennej _accountService typu IAccountService.
        private readonly IPasswordHasher<User> _passwordHasher;
        public AccountController(IAccountService accountService, IPasswordHasher<User> passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("register")] // Zadeklarowanie, że akcja jest odpowiedzialna za rejestrację użytkownika i dostępna przez ścieżkę "api/account/register"
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto); // Wywołanie metody RegisterUser na obiekcie _accountService i przekazanie argumentu dto.
            return Ok(); // Zwrócenie wyniku 200 OK.
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var account = _accountService.GetAccountByEmail(model.Email);
                var role = _accountService.GetRoleForAccount(model.Email);

                if (account != null)
                {
                    var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, model.PasswordHash);
                    if (passwordVerificationResult == PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Email),
                     new Claim(ClaimTypes.Role, role),            };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

                        Response.Cookies.Append("AuthCookie", "authenticated");

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return BadRequest();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest();
                }
            }
            return Ok();
        }
    }
}
