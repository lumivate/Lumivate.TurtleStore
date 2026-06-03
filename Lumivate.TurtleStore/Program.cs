using Lumivate.TurtleStore.Data;
using Lumivate.TurtleStore.Services;
using Microsoft.EntityFrameworkCore;

namespace Lumivate.TurtleStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // TODO-checkpoint-3 part A: Register the EF Core DbContext here
            // builder.Services.AddDbContext<TurtleStoreContext>(options =>
            //     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<TurtleStoreContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // TODO-checkpoint-4: Register TurtleService for dependency injection here
            // builder.Services.AddScoped<ITurtleService, TurtleService>();
            builder.Services.AddScoped<ITurtleService, TurtleService>();

            // TODO-checkpoint-6 part D: Register CartService and OrderService for dependency injection
            // builder.Services.AddScoped<ICartService, CartService>();
            // builder.Services.AddScoped<IOrderService, OrderService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
