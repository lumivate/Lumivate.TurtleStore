using Lumivate.TurtleStore.Models;

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
}
