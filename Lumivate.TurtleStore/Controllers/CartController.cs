using Lumivate.TurtleStore.Models;
using Lumivate.TurtleStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lumivate.TurtleStore.Controllers
{
    // TODO-checkpoint-6 part D: Create the CartController class
    // This controller should inherit from Controller.
    //
    // Accept ICartService via constructor injection:
    //   private readonly ICartService _cartService;
    //   public CartController(ICartService cartService) { _cartService = cartService; }
    //
    // Add the following actions:
    //   - Index() [HttpGet]: Display the current cart contents
    //     Return View() with _cartService.GetCartItems()
    //
    //   - Add(int turtleId) [HttpPost]: Add a turtle to the cart
    //     Call _cartService.AddToCart(turtleId)
    //     Redirect to the Turtles Index page
    //
    //   - Remove(int turtleId) [HttpPost]: Remove a turtle from the cart
    //     Call _cartService.RemoveFromCart(turtleId)
    //     Redirect to the Cart Index page
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_cartService.GetCartItems());
        }

        [HttpPost]
        public IActionResult Add(int turtleId)
        {
            _cartService.AddToCart(turtleId);
            return RedirectToAction("Index", "Turtles");
        }

        [HttpPost]
        public IActionResult Remove(int turtleId)
        {
            _cartService.RemoveFromCart(turtleId);
            return RedirectToAction("Index");
        }
    }
}
