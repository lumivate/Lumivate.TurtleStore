namespace Lumivate.TurtleStore.Models
{
    // TODO-checkpoint-1: Create the Turtle model class
    // This class represents a turtle in our store.
    // Add the following properties:
    //   - Id (int)
    //   - Name (string)
    //   - Species (string)
    //   - Description (string?) // Notice the ? which makes this nullable (it is optional)
    //   - Price (decimal)
    //   - IsAvailable (bool)
    public class Turtle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
