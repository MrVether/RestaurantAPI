using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RestaurantAPI.Controllers;
using RestaurantAPI.Entities;
using RestaurantAPI.Services;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantTests
{
    public class AccountControllerTests
    {
        private readonly Mock<ILogger<AccountController>> _loggerMock;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly Mock<IAuthenticationService> _authenticationServiceMock;
        private readonly Mock<IAccountService> _mockAccountService;


        public AccountControllerTests()
        {
            _loggerMock = new Mock<ILogger<AccountController>>();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _authenticationServiceMock = new Mock<IAuthenticationService>();
            _mockAccountService = new Mock<IAccountService>();
        }

        [Fact]
        public async Task Login_Returns_BadRequestResult_When_Login_Fails()
        {
            // Arrange
            var mockService = new Mock<IAccountService>();
            var mockPasswordHasher = new Mock<IPasswordHasher<User>>();
            var controller = new AccountController(mockService.Object, mockPasswordHasher.Object);
            var model = new User { Email = "test@test.com", PasswordHash = "hashed_password" };
            var account = new User { Email = "test@test.com", PasswordHash = "hashed_password" };

            mockService.Setup(s => s.GetAccountByEmail(model.Email)).Returns(account);
            mockService.Setup(s => s.GetRoleForAccount(model.Email)).Returns("User");
            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(account, account.PasswordHash, model.PasswordHash)).Returns(PasswordVerificationResult.Failed);

            // Act
            var result = await controller.Login(model);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}