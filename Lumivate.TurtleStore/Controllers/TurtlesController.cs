using Lumivate.TurtleStore.Models;
using Lumivate.TurtleStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lumivate.TurtleStore.Controllers
{
	// TODO-checkpoint-3 part B: Wire up the DbContext in the controller
	//   This is called dependency injection (DI) - we will cover it in depth in the next module.
	//   For now, just uncomment the following code. ASP.NET will automatically provide
	//   the TurtleStoreContext because you registered it in Program.cs.
	//
	//   using Lumivate.TurtleStore.Data;
	//
	//   private readonly TurtleStoreContext _context;
	//   public TurtlesController(TurtleStoreContext context)
	//   {
	//       _context = context;
	//   }


	// TODO-checkpoint-1: Create the TurtlesController class
	// This controller should inherit from Controller.
	// Add an Index() action that:
	//   1. Creates a static list of Turtle objects (hardcoded for now)
	//   2. Returns View(turtles) passing the list directly
	//
	// Example turtles to add (feel free to add your own though!)
	//   - "Shelly", Red-Eared Slider, $29.99, "A friendly and curious turtle."
	//   - "Tank", Box Turtle, $49.99, "A sturdy and calm companion."
	//   - "Speedy", Painted Turtle, $24.99, "Surprisingly quick for a turtle!"
	//
	// Tip: Take a look at the HomeController and copy the structure of the Index action to get started.
	//      The main difference will be adding a list of Turtles and passing it to the view, for example:
	//      List<Turtle> turtles = new List<Turtle> { ... };
	//      return View(turtles);

	// TODO-checkpoint-2: Refactor your Index action to use a TurtleViewModel
	//   - Create a TurtleViewModel and set its Turtles property to your list
	//   - Return View(viewModel) instead of View(turtles)

	// TODO-checkpoint-3 part B: Update your Index action to use the DbContext
	//   Replace your hardcoded list with:
	//   var turtles = _context.Turtles.ToList();

	// TODO-checkpoint-3 part C: Add a Details(int id) action
	//   - Use the DbContext to fetch a single turtle by id
	//   - If the turtle is not found, return NotFound()
	//   - Otherwise return View(turtle)

	// TODO-checkpoint-3 part D: Add Create() GET and POST actions
	//   - GET: return an empty form view, ie View()
	//   - POST: accept a Turtle model in the input parameters, save to database, redirect to Index (code below)
	//   [HttpPost]
	//   public IActionResult Create(Turtle turtle)
	//   {
	//       _context.Turtles.Add(turtle);
	//       _context.SaveChanges();
	//       return RedirectToAction(nameof(Index));
	//   }

	// TODO-checkpoint-3 part E: Add Edit() GET and POST actions
	//   - GET: fetch the turtle by id and return it to the form view
	//   - POST: accept the updated Turtle model, save changes to the database, redirect to Index
	//
	//   [HttpGet]
	//   public IActionResult Edit(int id)
	//   {
	//       var turtle = _context.Turtles.FirstOrDefault(t => t.Id == id);
	//       if (turtle == null)
	//       {
	//           return NotFound();
	//       }
	//       return View(turtle);
	//   }
	//
	//   [HttpPost]
	//   public IActionResult Edit(Turtle turtle)
	//   {
	//       var existing = _context.Turtles.FirstOrDefault(t => t.Id == turtle.Id);
	//       if (existing == null)
	//       {
	//           return NotFound();
	//       }
	//       existing.Name = turtle.Name;
	//       existing.Species = turtle.Species;
	//       existing.Description = turtle.Description;
	//       existing.Price = turtle.Price;
	//       existing.IsAvailable = turtle.IsAvailable;
	//       _context.SaveChanges();
	//       return RedirectToAction(nameof(Index));
	//   }

	// TODO-checkpoint-3 part F: Add Delete() GET and POST actions
	//   - GET: fetch the turtle by id and show a confirmation page
	//   - POST: remove the turtle from the database and redirect to Index
	//
	//   [HttpGet]
	//   public IActionResult Delete(int id)
	//   {
	//       var turtle = _context.Turtles.FirstOrDefault(t => t.Id == id);
	//       if (turtle == null)
	//       {
	//           return NotFound();
	//       }
	//       return View(turtle);
	//   }
	//
	//   [HttpPost, ActionName("Delete")]
	//   public IActionResult DeleteConfirmed(int id)
	//   {
	//       var turtle = _context.Turtles.FirstOrDefault(t => t.Id == id);
	//       if (turtle != null)
	//       {
	//           _context.Turtles.Remove(turtle);
	//           _context.SaveChanges();
	//       }
	//       return RedirectToAction(nameof(Index));
	//   }

	// TODO-checkpoint-4: Refactor this controller to accept ITurtleService via constructor injection
	//   - Replace TurtleStoreContext with ITurtleService in the constructor
	//   - Move all EF/DbContext logic into TurtleService and use _turtleService methods instead
	//   - Your controller will look so clean after this!
	public class TurtlesController : Controller
	{
		private readonly ITurtleService _turtleService;

		public TurtlesController(ITurtleService turtleService)
		{
			_turtleService = turtleService;
		}

		public IActionResult Index()
		{
			var turtles = _turtleService.GetAllTurtles();
			var viewModel = new TurtleViewModel { Turtles = turtles };
			return View(viewModel);
		}

		public IActionResult Details(int id)
		{
			var turtle = _turtleService.GetTurtleById(id);
			if (turtle == null)
			{
				return NotFound();
			}
			return View(turtle);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Turtle turtle)
		{
			_turtleService.AddTurtle(turtle);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var turtle = _turtleService.GetTurtleById(id);
			if (turtle == null)
			{
				return NotFound();
			}
			return View(turtle);
		}

		[HttpPost]
		public IActionResult Edit(Turtle turtle)
		{
			_turtleService.UpdateTurtle(turtle);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var turtle = _turtleService.GetTurtleById(id);
			if (turtle == null)
			{
				return NotFound();
			}
			return View(turtle);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			_turtleService.DeleteTurtle(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
