using Hotel.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Hotel.Ioc.Dependencies;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

builder.Services.AddRoomStatusDependecy();

builder.Services.AddRoomDependecy();

builder.Services.AddUserRolDependecy();

builder.Services.AddControllersWithViews();

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
