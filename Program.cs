using LibraryManagement.Models; 
using Microsoft.EntityFrameworkCore;

namespace EjercicioBibliotecaCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuración del DbContext
            builder.Services.AddDbContext<LibraryContext>(options =>
                options.UseInMemoryDatabase("LibraryDB"));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configurar el pipeline de solicitudes HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Cambiar la ruta predeterminada para que apunte a Home
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Asegúrate de tener rutas para Clientes, Productos y Pedidos
            app.MapControllerRoute(
                name: "clientes",
                pattern: "Clientes/{action=Index}/{id?}",
                defaults: new { controller = "Cliente" });

            app.MapControllerRoute(
                name: "productos",
                pattern: "Productos/{action=Index}/{id?}",
                defaults: new { controller = "Producto" });

            app.MapControllerRoute(
                name: "pedidos",
                pattern: "Pedidos/{action=Index}/{id?}",
                defaults: new { controller = "Pedido" });

            app.Run();
        }
    }
}
