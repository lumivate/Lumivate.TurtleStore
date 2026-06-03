using Lumivate.TurtleStore.Models;

namespace Lumivate.TurtleStore.Services
{
    // TODO-checkpoint-6 part B: Create the CartService class that implements ICartService
    //
    // This service manages the shopping cart. It should depend on ITurtleService
    // (injected via the constructor) to look up turtle details when adding items.
    //
    // Use a private static List<CartItem> as an in-memory cart store.
    //
    // Implement all methods from ICartService:
    //   - GetCartItems(): return the full cart
    //   - AddToCart(int turtleId): look up the turtle, add or increment quantity
    //   - RemoveFromCart(int turtleId): remove the item with matching TurtleId
    //   - GetCartTotal(): sum up (Price * Quantity) for all items
    //   - ClearCart(): empty the cart

    // After creating this class, you will register it in Program.cs during part D:
    //   builder.Services.AddScoped<ICartService, CartService>();
    public class CartService : ICartService
    {
        private static List<CartItem> _cartItems = new List<CartItem>();
        private readonly ITurtleService _turtleService;

        public CartService(ITurtleService turtleService)
        {
            _turtleService = turtleService;
        }

        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }

        public void AddToCart(int turtleId)
        {
            var existingItem = _cartItems.FirstOrDefault(i => i.TurtleId == turtleId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var turtle = _turtleService.GetTurtleById(turtleId);
                if (turtle != null)
                {
                    _cartItems.Add(new CartItem
                    {
                        TurtleId = turtleId,
                        Turtle = turtle,
                        Quantity = 1
                    });
                }
            }
        }

        public void RemoveFromCart(int turtleId)
        {
            var item = _cartItems.FirstOrDefault(i => i.TurtleId == turtleId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }

        public decimal GetCartTotal()
        {
            return _cartItems.Sum(i => i.Turtle.Price * i.Quantity);
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }
    }
}
