// TODO-checkpoint-6 part F: Create unit tests for CartService using xUnit
//
// 1. Add the following using statements:
//    using Lumivate.TurtleStore.Data;
//    using Lumivate.TurtleStore.Models;
//    using Lumivate.TurtleStore.Services;
//    using Microsoft.EntityFrameworkCore;
//    using Xunit;
//
// 2. Create a test class called CartServiceTests
//
// 3. Add a helper method to create a seeded InMemory DbContext for each test:
//    (TurtleService requires a TurtleStoreContext, so we need to seed turtles in memory)
//
//    private TurtleStoreContext GetSeededContext()
//    {
//        var options = new DbContextOptionsBuilder<TurtleStoreContext>()
//            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//            .Options;
//        var context = new TurtleStoreContext(options);
//        context.Turtles.AddRange(
//            new Turtle { Id = 1, Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, IsAvailable = true },
//            new Turtle { Id = 2, Name = "Tank", Species = "Box Turtle", Price = 49.99m, IsAvailable = true },
//            new Turtle { Id = 3, Name = "Speedy", Species = "Painted Turtle", Price = 24.99m, IsAvailable = true }
//        );
//        context.SaveChanges();
//        return context;
//    }
//
// 4. Write the following test methods using the [Fact] attribute:
//
//    [Fact]
//    public void AddToCart_AddsItemToCart()
//    {
//        // Arrange
//        var context = GetSeededContext();
//        var turtleService = new TurtleService(context);
//        var cartService = new CartService(turtleService);
//
//        // Act
//        cartService.AddToCart(1);
//        var items = cartService.GetCartItems();
//
//        // Assert
//        Assert.Single(items);
//        Assert.Equal(1, items[0].TurtleId);
//
//        // Clean up static state
//        cartService.ClearCart();
//    }
//
//    [Fact]
//    public void AddToCart_SameTurtleTwice_IncreasesQuantity()
//    {
//        // Arrange
//        var context = GetSeededContext();
//        var turtleService = new TurtleService(context);
//        var cartService = new CartService(turtleService);
//
//        // Act
//        cartService.AddToCart(1);
//        cartService.AddToCart(1);
//        var items = cartService.GetCartItems();
//
//        // Assert
//        Assert.Single(items);
//        Assert.Equal(2, items[0].Quantity);
//
//        // Clean up static state
//        cartService.ClearCart();
//    }
//
//    [Fact]
//    public void RemoveFromCart_RemovesItem()
//    {
//        // Arrange
//        var context = GetSeededContext();
//        var turtleService = new TurtleService(context);
//        var cartService = new CartService(turtleService);
//        cartService.AddToCart(1);
//
//        // Act
//        cartService.RemoveFromCart(1);
//        var items = cartService.GetCartItems();
//
//        // Assert
//        Assert.Empty(items);
//
//        // Clean up static state
//        cartService.ClearCart();
//    }
//
//    [Fact]
//    public void ClearCart_RemovesAllItems()
//    {
//        // Arrange
//        var context = GetSeededContext();
//        var turtleService = new TurtleService(context);
//        var cartService = new CartService(turtleService);
//        cartService.AddToCart(1);
//        cartService.AddToCart(2);
//
//        // Act
//        cartService.ClearCart();
//        var items = cartService.GetCartItems();
//
//        // Assert
//        Assert.Empty(items);
//    }

using Lumivate.TurtleStore.Data;
using Lumivate.TurtleStore.Models;
using Lumivate.TurtleStore.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Lumivate.TurtleStore.Tests
{
    // TODO-checkpoint-6 part F: Uncomment and complete the test class above
    public class CartServiceTests
    {
        private TurtleStoreContext GetSeededContext()
        {
            var options = new DbContextOptionsBuilder<TurtleStoreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new TurtleStoreContext(options);
            context.Turtles.AddRange(
                new Turtle { Id = 1, Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, IsAvailable = true },
                new Turtle { Id = 2, Name = "Tank", Species = "Box Turtle", Price = 49.99m, IsAvailable = true },
                new Turtle { Id = 3, Name = "Speedy", Species = "Painted Turtle", Price = 24.99m, IsAvailable = true }
            );
            context.SaveChanges();
            return context;
        }

        [Fact]
        public void AddToCart_AddsItemToCart()
        {
            // Arrange
            var context = GetSeededContext();
            var turtleService = new TurtleService(context);
            var cartService = new CartService(turtleService);

            // Act
            cartService.AddToCart(1);
            var items = cartService.GetCartItems();

            // Assert
            Assert.Single(items);
            Assert.Equal(1, items[0].TurtleId);

            // Clean up static state
            cartService.ClearCart();
        }

        [Fact]
        public void AddToCart_SameTurtleTwice_IncreasesQuantity()
        {
            // Arrange
            var context = GetSeededContext();
            var turtleService = new TurtleService(context);
            var cartService = new CartService(turtleService);

            // Act
            cartService.AddToCart(1);
            cartService.AddToCart(1);
            var items = cartService.GetCartItems();

            // Assert
            Assert.Single(items);
            Assert.Equal(2, items[0].Quantity);

            // Clean up static state
            cartService.ClearCart();
        }

        [Fact]
        public void RemoveFromCart_RemovesItem()
        {
            // Arrange
            var context = GetSeededContext();
            var turtleService = new TurtleService(context);
            var cartService = new CartService(turtleService);
            cartService.AddToCart(1);

            // Act
            cartService.RemoveFromCart(1);
            var items = cartService.GetCartItems();

            // Assert
            Assert.Empty(items);

            // Clean up static state
            cartService.ClearCart();
        }

        [Fact]
        public void ClearCart_RemovesAllItems()
        {
            // Arrange
            var context = GetSeededContext();
            var turtleService = new TurtleService(context);
            var cartService = new CartService(turtleService);
            cartService.AddToCart(1);
            cartService.AddToCart(2);

            // Act
            cartService.ClearCart();
            var items = cartService.GetCartItems();

            // Assert
            Assert.Empty(items);
        }
    }
}
