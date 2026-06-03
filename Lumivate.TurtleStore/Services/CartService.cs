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
}
