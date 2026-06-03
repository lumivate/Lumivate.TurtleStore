using Lumivate.TurtleStore.Models;

namespace Lumivate.TurtleStore.Services
{
	// TODO-checkpoint-6 part C: Create the IOrderService interface
	// Define the following method signatures. Make sure these signatures match the methods you will implement in OrderService.cs.
	//   - Order PlaceOrder(string customerName, List<CartItem> items)
	//   - Order? GetOrderById(int id)
	//   - List<Order> GetAllOrders()
	public interface IOrderService
	{
		Order PlaceOrder(string customerName, List<CartItem> items);
		Order? GetOrderById(int id);
		List<Order> GetAllOrders();
	}
}
