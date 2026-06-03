// TODO-checkpoint-5: Create unit tests for TurtlesController using xUnit and Moq
//
// 1. Add the following using statements:
//    using Lumivate.TurtleStore.Controllers;
//    using Lumivate.TurtleStore.Models;
//    using Lumivate.TurtleStore.Services;
//    using Microsoft.AspNetCore.Mvc;
//    using Moq;
//    using Xunit;
//
// 2. Create a test class called TurtlesControllerTests
//
// 3. Write the following test methods using the [Fact] attribute:
//
//    [Fact]
//    public void Index_ReturnsViewWithTurtles()
//    {
//        // Arrange
//        var mockService = new Mock<ITurtleService>();
//        mockService.Setup(s => s.GetAllTurtles()).Returns(new List<Turtle>
//        {
//            new Turtle { Id = 1, Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, IsAvailable = true }
//        });
//        var controller = new TurtlesController(mockService.Object);
//
//        // Act
//        var result = controller.Index() as ViewResult;
//
//        // Assert
//        Assert.NotNull(result);
//    }
//
//    [Fact]
//    public void Details_WithValidId_ReturnsViewWithTurtle()
//    {
//        // Arrange
//        var mockService = new Mock<ITurtleService>();
//        mockService.Setup(s => s.GetTurtleById(1)).Returns(
//            new Turtle { Id = 1, Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, IsAvailable = true }
//        );
//        var controller = new TurtlesController(mockService.Object);
//
//        // Act
//        var result = controller.Details(1) as ViewResult;
//
//        // Assert
//        Assert.NotNull(result);
//    }
//
//    [Fact]
//    public void Details_WithInvalidId_ReturnsNotFound()
//    {
//        // Arrange
//        var mockService = new Mock<ITurtleService>();
//        mockService.Setup(s => s.GetTurtleById(999)).Returns((Turtle?)null);
//        var controller = new TurtlesController(mockService.Object);
//
//        // Act
//        var result = controller.Details(999);
//
//        // Assert
//        Assert.IsType<NotFoundResult>(result);
//    }

using Lumivate.TurtleStore.Controllers;
using Lumivate.TurtleStore.Models;
using Lumivate.TurtleStore.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Lumivate.TurtleStore.Tests
{
    // TODO-checkpoint-5: Uncomment and complete the test class above
    public class TurtlesControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithTurtles()
        {
            // Arrange
            var mockService = new Mock<ITurtleService>();
            mockService.Setup(s => s.GetAllTurtles()).Returns(new List<Turtle>
            {
                new Turtle { Id = 1, Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, IsAvailable = true }
            });
            var controller = new TurtlesController(mockService.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Details_WithValidId_ReturnsViewWithTurtle()
        {
            // Arrange
            var mockService = new Mock<ITurtleService>();
            mockService.Setup(s => s.GetTurtleById(1)).Returns(
                new Turtle { Id = 1, Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, IsAvailable = true }
            );
            var controller = new TurtlesController(mockService.Object);

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Details_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockService = new Mock<ITurtleService>();
            mockService.Setup(s => s.GetTurtleById(999)).Returns((Turtle?)null);
            var controller = new TurtlesController(mockService.Object);

            // Act
            var result = controller.Details(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
