using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace RestaurantAPI.Controllers
{
    public class RestaurantControllerTests
    {

        [Fact]
        public void CreateRestaurant_Returns_CreatedResult()
        {
            // Arrange
            var mockService = new Mock<IRestaurantService>();
            mockService.Setup(s => s.Create(It.IsAny<CreateRestaurantDto>())).Returns(1);
            var controller = new RestaurantController(mockService.Object);

            var dto = new CreateRestaurantDto();

            // Act
            var result = controller.CreateRestaurant(dto);

            // Assert
            Assert.IsType<CreatedResult>(result);
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal("/api/restaurant/1", createdResult.Location);

        }


        [Fact]
        public void GetAll_Returns_OkResult_With_RestaurantDtos()
        {
            // Arrange
            var mockService = new Mock<IRestaurantService>();
            var expectedDtos = new List<RestaurantDto> { new RestaurantDto(), new RestaurantDto() };
            mockService.Setup(s => s.GetAll()).Returns(expectedDtos);
            var controller = new RestaurantController(mockService.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            // Assert
            Assert.IsType<ActionResult<IEnumerable<RestaurantDto>>>(result);
            var actionResult = Assert.IsType<ActionResult<IEnumerable<RestaurantDto>>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(expectedDtos, okObjectResult.Value);

        }
        [Fact]
        public void Update_Returns_OkResult_WhenAuthorized()
        {
            // Arrange
            var mockService = new Mock<IRestaurantService>();
            var controller = new RestaurantController(mockService.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
            new Claim(ClaimTypes.Role, "Admin")
                    }, "mock"))
                }
            };

            var dto = new UpdateRestaurantDto();

            // Act
            var result = controller.Update(dto, 1);

            // Assert
            Assert.IsType<OkResult>(result);

        }
    }
}