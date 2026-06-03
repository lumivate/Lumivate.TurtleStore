using Lumivate.TurtleStore.Data;
using Lumivate.TurtleStore.Models;

namespace Lumivate.TurtleStore.Services
{
    // TODO-checkpoint-4: Create the TurtleService class that implements ITurtleService
    //   public class TurtleService : ITurtleService
    //
    // This service will contain the business logic for turtle operations.
    //
    // Inject the TurtleStoreContext into the constructor (just like TurtlesController has):
    //   private readonly TurtleStoreContext _context;
    //   public TurtleService(TurtleStoreContext context)
    //   {
    //       _context = context;
    //   }
    //
    // Then implement all methods from ITurtleService.
    // The logic should be the same as what is currently in your controller
    // where you pulled data from the DbContext:
    //   - GetAllTurtles(): return _context.Turtles.ToList()
    //   - GetTurtleById(int id): return _context.Turtles.FirstOrDefault(t => t.Id == id)
    //   - AddTurtle(Turtle turtle): _context.Turtles.Add(turtle); _context.SaveChanges();
    //   - UpdateTurtle(Turtle turtle): find existing by Id, update properties, SaveChanges()
    //   - DeleteTurtle(int id): find by Id, Remove(), SaveChanges()

    // TODO-checkpoint-4: After creating this class, register it in Program.cs:
    //   builder.Services.AddScoped<ITurtleService, TurtleService>();
    public class TurtleService : ITurtleService
    {
        private readonly TurtleStoreContext _context;

        public TurtleService(TurtleStoreContext context)
        {
            _context = context;
        }

        public List<Turtle> GetAllTurtles()
        {
            return _context.Turtles.ToList();
        }

        public Turtle? GetTurtleById(int id)
        {
            return _context.Turtles.FirstOrDefault(t => t.Id == id);
        }

        public void AddTurtle(Turtle turtle)
        {
            _context.Turtles.Add(turtle);
            _context.SaveChanges();
        }

        public void UpdateTurtle(Turtle turtle)
        {
            var existing = _context.Turtles.FirstOrDefault(t => t.Id == turtle.Id);
            if (existing != null)
            {
                existing.Name = turtle.Name;
                existing.Species = turtle.Species;
                existing.Description = turtle.Description;
                existing.Price = turtle.Price;
                existing.IsAvailable = turtle.IsAvailable;
                _context.SaveChanges();
            }
        }

        public void DeleteTurtle(int id)
        {
            var turtle = _context.Turtles.FirstOrDefault(t => t.Id == id);
            if (turtle != null)
            {
                _context.Turtles.Remove(turtle);
                _context.SaveChanges();
            }
        }
    }
}
