using Lumivate.TurtleStore.Models;

namespace Lumivate.TurtleStore.Services
{
    // TODO-checkpoint-6 part C: Create the OrderService class that implements IOrderService
    //
    // This service manages customer orders.
    // Use a private static List<Order> as an in-memory order store.
    //
    // Implement all methods from IOrderService:
    //   - PlaceOrder(string customerName, List<CartItem> items):
    //     Create a new Order with a generated Id, the customer name, current date,
    //     and convert CartItems to OrderItems. Calculate the total.
    //   - GetOrderById(int id): return the order with the matching Id
    //   - GetAllOrders(): return all orders

    // After creating this class, you will register it in Program.cs during part D:
    //   builder.Services.AddScoped<IOrderService, OrderService>();
    public class OrderService : IOrderService
    {
        private static List<Order> _orders = new List<Order>();

        public Order PlaceOrder(string customerName, List<CartItem> items)
        {
            var order = new Order
            {
                Id = _orders.Count + 1,
                CustomerName = customerName,
                OrderDate = DateTime.Now,
                Items = items.Select(i => new OrderItem
                {
                    TurtleId = i.TurtleId,
                    Turtle = i.Turtle,
                    Quantity = i.Quantity,
                    UnitPrice = i.Turtle.Price
                }).ToList(),
                Total = items.Sum(i => i.Turtle.Price * i.Quantity)
            };

            _orders.Add(order);
            return order;
        }

        public Order? GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAllOrders()
        {
            return _orders;
        }
    }
}
