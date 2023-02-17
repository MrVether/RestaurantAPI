using Microsoft.AspNetCore.Mvc;
using Moq;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Collections.Generic;
using Xunit;

namespace RestaurantAPI.Controllers
{
    public class DishControllerTests
    {
        [Fact]
        public void Delete_Returns_NoContent()
        {
            // Arrange
            var mockService = new Mock<IDishService>();
            var controller = new DishController(mockService.Object);
            var restaurantId = 1;

            // Act
            var result = controller.Delete(restaurantId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void GetAll_Returns_OkResult_With_DishDtos()
        {
            // Arrange
            var mockService = new Mock<IDishService>();
            var controller = new DishController(mockService.Object);
            var restaurantId = 1;
            var expectedDtos = new List<DishDto> { new DishDto(), new DishDto() };

            mockService.Setup(s => s.GetAll(restaurantId)).Returns(expectedDtos);

            // Act
            var result = controller.Get(restaurantId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualDtos = Assert.IsAssignableFrom<List<DishDto>>(okObjectResult.Value);
            Assert.Equal(expectedDtos, actualDtos);
        }




        [Fact]
        public void Get_Returns_OkResult_With_DishDto()
        {
            // Arrange
            var mockService = new Mock<IDishService>();
            var controller = new DishController(mockService.Object);
            var restaurantId = 1;
            var dishId = 1;
            var expectedDto = new DishDto();

            mockService.Setup(s => s.GetById(restaurantId, dishId)).Returns(expectedDto);

            // Act
            var result = controller.Get(restaurantId, dishId);

            // Assert
            Assert.IsType<ActionResult<DishDto>>(result);
        }

    }
}
