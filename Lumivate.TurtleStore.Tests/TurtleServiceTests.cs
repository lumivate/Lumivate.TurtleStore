// TODO-checkpoint-5: Create unit tests for TurtleService using xUnit
//
// Since TurtleService uses TurtleStoreContext (a real database),
// we need to use EF Core's InMemory database provider for testing.
// This creates a fake database in memory so tests run fast and don't need SQL Server.
//
// 1. Add the following using statements:
//    using Lumivate.TurtleStore.Data;
//    using Lumivate.TurtleStore.Models;
//    using Lumivate.TurtleStore.Services;
//    using Microsoft.EntityFrameworkCore;
//    using Xunit;
//
// 2. Create a test class called TurtleServiceTests
//
// 3. Add a helper method to create a fresh InMemory DbContext for each test:
//    private TurtleStoreContext GetInMemoryContext()
//    {
//        var options = new DbContextOptionsBuilder<TurtleStoreContext>()
//            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//            .Options;
//        return new TurtleStoreContext(options);
//    }
//
// 4. Write the following test methods using the [Fact] attribute:
//
//    [Fact]
//    public void AddTurtle_IncreasesCount()
//    {
//        // Arrange
//        var context = GetInMemoryContext();
//        var service = new TurtleService(context);
//        var newTurtle = new Turtle
//        {
//            Name = "Test Turtle",
//            Species = "Test Species",
//            Price = 9.99m,
//            IsAvailable = true
//        };
//
//        // Act
//        service.AddTurtle(newTurtle);
//
//        // Assert
//        Assert.Equal(1, service.GetAllTurtles().Count);
//    }
//
//    [Fact]
//    public void GetTurtleById_WithValidId_ReturnsTurtle()
//    {
//        // Arrange
//        var context = GetInMemoryContext();
//        var service = new TurtleService(context);
//        var turtle = new Turtle { Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, IsAvailable = true };
//        service.AddTurtle(turtle);
//
//        // Act
//        var result = service.GetTurtleById(turtle.Id);
//
//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal("Shelly", result.Name);
//    }
//
//    [Fact]
//    public void GetTurtleById_WithInvalidId_ReturnsNull()
//    {
//        // Arrange
//        var context = GetInMemoryContext();
//        var service = new TurtleService(context);
//
//        // Act
//        var result = service.GetTurtleById(999);
//
//        // Assert
//        Assert.Null(result);
//    }
//
//    [Fact]
//    public void DeleteTurtle_RemovesTurtle()
//    {
//        // Arrange
//        var context = GetInMemoryContext();
//        var service = new TurtleService(context);
//        var turtle = new Turtle { Name = "Tank", Species = "Box Turtle", Price = 49.99m, IsAvailable = true };
//        service.AddTurtle(turtle);
//
//        // Act
//        service.DeleteTurtle(turtle.Id);
//
//        // Assert
//        Assert.Null(service.GetTurtleById(turtle.Id));
//    }

namespace Lumivate.TurtleStore.Tests
{
    // TODO-checkpoint-5: Uncomment and complete the test class above
}
