using Lumivate.TurtleStore.Models;

namespace Lumivate.TurtleStore.Services
{
	// TODO-checkpoint-4: Create the ITurtleService interface
	// Define the following method signatures. Make sure these signatures match the methods you will implement in TurtleService.cs.
	//   - List<Turtle> GetAllTurtles()
	//   - Turtle? GetTurtleById(int id)
	//   - void AddTurtle(Turtle turtle)
	//   - void UpdateTurtle(Turtle turtle)
	//   - void DeleteTurtle(int id)
	public interface ITurtleService
	{
		List<Turtle> GetAllTurtles();
		Turtle? GetTurtleById(int id);
		void AddTurtle(Turtle turtle);
		void UpdateTurtle(Turtle turtle);
		void DeleteTurtle(int id);
	}
}
