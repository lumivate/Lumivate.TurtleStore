using Lumivate.TurtleStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lumivate.TurtleStore.Controllers
{
    // TODO-checkpoint-6 part E: Create the OrdersController class
    // This controller should inherit from Controller.
    // It should accept IOrderService and ICartService via constructor injection.
    //
    // Add the following actions:
    //   - Checkout() [HttpGet]: Display the checkout form
    //     Return View() with a new Order object
    //
    //   - Checkout(Order order) [HttpPost]: Process the order
    //     Use the ICartService to get the current cart items
    //     Use the IOrderService to place the order
    //     Clear the cart after placing the order
    //     Redirect to Confirmation with the order id
    //
    //   - Confirmation(int id) [HttpGet]: Display the order confirmation
    //     Use the IOrderService to fetch the order by id
    //     Return View(order)
}
