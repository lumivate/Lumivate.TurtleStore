// TODO-checkpoint-6 part F: Create unit tests for OrderService using xUnit
//
// 1. Add the following using statements:
//    using Lumivate.TurtleStore.Models;
//    using Lumivate.TurtleStore.Services;
//    using Xunit;
//
// 2. Create a test class called OrderServiceTests
//
// 3. Write the following test methods using the [Fact] attribute:
//
//    Hint: You will need to create CartItem objects to pass to PlaceOrder.
//    A CartItem needs a TurtleId, a Turtle object (with Name and Price), and a Quantity.
//
//    [Fact]
//    public void PlaceOrder_CreatesOrderWithCorrectCustomerName()
//    {
//        // Arrange - create an OrderService and a list of CartItems
//        // Act - call PlaceOrder with a customer name and the cart items
//        // Assert - verify the returned order has the correct CustomerName
//    }
//
//    [Fact]
//    public void PlaceOrder_CalculatesCorrectTotal()
//    {
//        // Arrange - create cart items with known prices and quantities
//        // Act - call PlaceOrder
//        // Assert - verify the Total equals the sum of (UnitPrice * Quantity) for each item
//    }
//
//    [Fact]
//    public void GetOrderById_WithValidId_ReturnsOrder()
//    {
//        // Arrange - place an order first to get an order with a known id
//        // Act - call GetOrderById with that id
//        // Assert - verify the returned order is not null and has the correct id
//    }
//
//    [Fact]
//    public void GetOrderById_WithInvalidId_ReturnsNull()
//    {
//        // Arrange - create an OrderService (don't place any orders)
//        // Act - call GetOrderById with an id that doesn't exist (e.g., 999)
//        // Assert - verify the result is null
//    }

using Lumivate.TurtleStore.Models;
using Lumivate.TurtleStore.Services;
using Xunit;

namespace Lumivate.TurtleStore.Tests
{
    // TODO-checkpoint-6 part F: Uncomment and complete the test class above
    // Unlike the previous test files, this one has less code provided.
    // Use the TurtleServiceTests as a reference for the Arrange-Act-Assert pattern.
    public class OrderServiceTests
    {
        private List<CartItem> CreateTestCartItems()
        {
            return new List<CartItem>
            {
                new CartItem
                {
                    TurtleId = 1,
                    Turtle = new Turtle { Id = 1, Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, IsAvailable = true },
                    Quantity = 2
                },
                new CartItem
                {
                    TurtleId = 2,
                    Turtle = new Turtle { Id = 2, Name = "Tank", Species = "Box Turtle", Price = 49.99m, IsAvailable = true },
                    Quantity = 1
                }
            };
        }

        [Fact]
        public void PlaceOrder_CreatesOrderWithCorrectCustomerName()
        {
            // Arrange
            var orderService = new OrderService();
            var cartItems = CreateTestCartItems();

            // Act
            var order = orderService.PlaceOrder("John Doe", cartItems);

            // Assert
            Assert.Equal("John Doe", order.CustomerName);
        }

        [Fact]
        public void PlaceOrder_CalculatesCorrectTotal()
        {
            // Arrange
            var orderService = new OrderService();
            var cartItems = CreateTestCartItems();

            // Act
            var order = orderService.PlaceOrder("John Doe", cartItems);

            // Assert - Total should be (29.99 * 2) + (49.99 * 1) = 109.97
            Assert.Equal(109.97m, order.Total);
        }

        [Fact]
        public void GetOrderById_WithValidId_ReturnsOrder()
        {
            // Arrange
            var orderService = new OrderService();
            var cartItems = CreateTestCartItems();
            var placedOrder = orderService.PlaceOrder("John Doe", cartItems);

            // Act
            var result = orderService.GetOrderById(placedOrder.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(placedOrder.Id, result.Id);
        }

        [Fact]
        public void GetOrderById_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var orderService = new OrderService();

            // Act
            var result = orderService.GetOrderById(999);

            // Assert
            Assert.Null(result);
        }
    }
}
