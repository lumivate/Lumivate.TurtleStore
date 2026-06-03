// TODO-checkpoint-6 part F: Create unit tests for OrderService using xUnit
//
// Since OrderService uses TurtleStoreContext (a real database),
// we use EF Core's InMemory database provider for testing, just like
// in TurtleServiceTests and CartServiceTests.
//
// 1. Add the following using statements:
//    using Lumivate.TurtleStore.Data;
//    using Lumivate.TurtleStore.Models;
//    using Lumivate.TurtleStore.Services;
//    using Microsoft.EntityFrameworkCore;
//    using Xunit;
//
// 2. Create a test class called OrderServiceTests
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
//    Hint: You will need to create CartItem objects to pass to PlaceOrder.
//    A CartItem needs a TurtleId, a Turtle object (with Name and Price), and a Quantity.
//
//    [Fact]
//    public void PlaceOrder_CreatesOrderWithCorrectCustomerName()
//    {
//        // Arrange - create an OrderService with an InMemory context and a list of CartItems
//        // Act - call PlaceOrder with a customer name and the cart items
//        // Assert - verify the returned order has the correct CustomerName
//    }
//        // Assert - verify the result is null
//    }

using Lumivate.TurtleStore.Data;
using Lumivate.TurtleStore.Models;
using Lumivate.TurtleStore.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Lumivate.TurtleStore.Tests
    // Use the TurtleServiceTests as a reference for the Arrange-Act-Assert pattern.
    public class OrderServiceTests
    {
        private TurtleStoreContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TurtleStoreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new TurtleStoreContext(options);
        }

        private List<CartItem> CreateTestCartItems()
        {
            return new List<CartItem>
        public void PlaceOrder_CreatesOrderWithCorrectCustomerName()
        {
            // Arrange
            var context = GetInMemoryContext();
            var orderService = new OrderService(context);
            var cartItems = CreateTestCartItems();

            // Act
        public void PlaceOrder_CalculatesCorrectTotal()
        {
            // Arrange
            var context = GetInMemoryContext();
            var orderService = new OrderService(context);
            var cartItems = CreateTestCartItems();

            // Act
        public void GetOrderById_WithValidId_ReturnsOrder()
        {
            // Arrange
            var context = GetInMemoryContext();
            var orderService = new OrderService(context);
            var cartItems = CreateTestCartItems();
            var placedOrder = orderService.PlaceOrder("John Doe", cartItems);

        public void GetOrderById_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var context = GetInMemoryContext();
            var orderService = new OrderService(context);

            // Act
            var result = orderService.GetOrderById(999);

            // Assert
            Assert.Null(result);
        }
    }
}
