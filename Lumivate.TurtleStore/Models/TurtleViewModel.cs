namespace Lumivate.TurtleStore.Models
{
    // TODO-checkpoint-2: Create a TurtleViewModel class
    // This ViewModel wraps the turtle list for the view.
    // Add the following properties:
    //   - Turtles (List<Turtle>)
    //   - SearchTerm (string?) - optional, for future filtering
    public class TurtleViewModel
    {
        public List<Turtle> Turtles { get; set; } = new List<Turtle>();
        public string? SearchTerm { get; set; }
    }
}
