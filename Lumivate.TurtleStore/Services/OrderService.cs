using Lumivate.TurtleStore.Data;
using Lumivate.TurtleStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Lumivate.TurtleStore.Services
{
    // TODO-checkpoint-6 part C: Create the OrderService class that implements IOrderService
    //
    // This service manages customer orders.
    //
    // Inject TurtleStoreContext into the constructor (just like TurtleService does):
    //   private readonly TurtleStoreContext _context;
    //   public OrderService(TurtleStoreContext context)
    //   {
    //       _context = context;
    //   }
    //
    // Implement all methods from IOrderService using _context for all database operations:
    //   - PlaceOrder(string customerName, List<CartItem> items):
    //     Create a new Order with the customer name, current date, and convert
    //     CartItems to OrderItems. Calculate the total. Add the order to
    //     _context.Orders and call _context.SaveChanges(). The database will
    //     generate the Id automatically.
    //   - GetOrderById(int id): return _context.Orders.FirstOrDefault(o => o.Id == id)
    //   - GetAllOrders(): return _context.Orders.ToList()

    // After creating this class, you will register it in Program.cs during part D:
    //   builder.Services.AddScoped<IOrderService, OrderService>();
    public class OrderService : IOrderService
    {
        private readonly TurtleStoreContext _context;

        public OrderService(TurtleStoreContext context)
        {
            _context = context;
        }

        public Order PlaceOrder(string customerName, List<CartItem> items)
        {
            var order = new Order
            {
                CustomerName = customerName,
                OrderDate = DateTime.Now,
                Items = items.Select(i => new OrderItem
                {
                    TurtleId = i.TurtleId,
                    Quantity = i.Quantity,
                    UnitPrice = i.Turtle.Price
                }).ToList(),
                Total = items.Sum(i => i.Turtle.Price * i.Quantity)
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Items)
                .ToList();
        }
    }
}
