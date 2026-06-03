namespace Lumivate.TurtleStore.Models
{
    // TODO-checkpoint-6 part B: Create the CartItem model class
    // This class represents an item in the shopping cart.
    // Add the following properties:
    //   - TurtleId (int)
    //   - Turtle (Turtle) - navigation property to the Turtle being purchased
    //   - Quantity (int)
    public class CartItem
    {
        public int TurtleId { get; set; }
        public Turtle Turtle { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
