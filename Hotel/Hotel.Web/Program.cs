
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Hotel.Ioc.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Agregar dependencias del contexto // NOTE: This part should be added in the IoC
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));


//Repositories: Cliente and Recepcion  //NOTE: This part is already added in the IoC
//builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
//builder.Services.AddTransient<IRecepcionRepository, RecepcionRepository>();


//Dependencies - IoC
builder.Services.AddClienteDependency();
builder.Services.AddRecepcionDependency();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
