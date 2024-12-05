using AutoMapper; // Importa AutoMapper
using Microsoft.EntityFrameworkCore;
using GimnasioMVC.Data;
using GimnasioMVC.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Registra AutoMapper en el contenedor de dependencias
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Registra el contexto de base de datos con la cadena de conexión
builder.Services.AddDbContext<GimnasioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega los repositorios a los servicios
builder.Services.AddScoped<ISocioRepositorio, SocioRepositorio>();
builder.Services.AddScoped<IClaseRepositorio, ClaseRepositorio>();

// Agrega los servicios MVC para vistas y controladores
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura el pipeline de solicitudes
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configura las rutas estándar
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Rutas personalizadas para Socios y Clases
app.MapControllerRoute(
    name: "socios",
    pattern: "socios/{action=Index}/{id?}",
    defaults: new { controller = "Socios" });

app.MapControllerRoute(
    name: "clases",
    pattern: "clases/{action=Index}/{id?}",
    defaults: new { controller = "Clases" });

app.Run();