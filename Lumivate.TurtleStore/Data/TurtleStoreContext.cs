// TODO-checkpoint-3 part A: Add the following using statements:
//   using Lumivate.TurtleStore.Models;
//   using Microsoft.EntityFrameworkCore;
using Lumivate.TurtleStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Lumivate.TurtleStore.Data
{
	// TODO-checkpoint-3 part A: Create the TurtleStoreContext class
	// This class should inherit from DbContext, ie...
	//      public class TurtleStoreContext : DbContext { }
	//
	// 1. Add a constructor that accepts DbContextOptions<TurtleStoreContext> and passes it to the base class, ie...
	//      public TurtleStoreContext(DbContextOptions<TurtleStoreContext> options) : base(options) { }
	//
	// 2. Add a DbSet property for your Turtles:
	//      public DbSet<Turtle> Turtles { get; set; }
	//
	// 3. Override OnModelCreating to seed sample data. Uncomment the following...
	//      protected override void OnModelCreating(ModelBuilder modelBuilder)
	//      {
	//          modelBuilder.Entity<Turtle>().HasData(
	//              new Turtle { Id = 1, Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, Description = "A friendly and curious turtle.", IsAvailable = true },
	//              new Turtle { Id = 2, Name = "Tank", Species = "Box Turtle", Price = 49.99m, Description = "A sturdy and calm companion.", IsAvailable = true },
	//              new Turtle { Id = 3, Name = "Speedy", Species = "Painted Turtle", Price = 24.99m, Description = "Surprisingly quick for a turtle!", IsAvailable = true }
	//          );
	//      }
	//
	// TODO-checkpoint-6 part A: Add DbSet properties for Orders and OrderItems:
	//      public DbSet<Order> Orders { get; set; }
	//      public DbSet<OrderItem> OrderItems { get; set; }

	//   Then create a new migration. From your IDE's terminal
	//   (View > Terminal in Visual Studio or VS Code), run:
	//     dotnet ef migrations add AddOrderTables
	//     dotnet ef database update

	public class TurtleStoreContext : DbContext
	{
		public TurtleStoreContext(DbContextOptions<TurtleStoreContext> options) : base(options) { }

		public DbSet<Turtle> Turtles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Turtle>().HasData(
				new Turtle { Id = 1, Name = "Shelly", Species = "Red-Eared Slider", Price = 29.99m, Description = "A friendly and curious turtle.", IsAvailable = true },
				new Turtle { Id = 2, Name = "Tank", Species = "Box Turtle", Price = 49.99m, Description = "A sturdy and calm companion.", IsAvailable = true },
				new Turtle { Id = 3, Name = "Speedy", Species = "Painted Turtle", Price = 24.99m, Description = "Surprisingly quick for a turtle!", IsAvailable = true }
			);
		}
	}
}
