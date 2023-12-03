
using Hotel.Infraestructure.Context;
using Hotel.Ioc.Dependencies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agregar dependencias del contexto //
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));


// ****Dependencias de los repositorios**********


//builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
//builder.Services.AddTransient<IRecepcionRepository, RecepcionRepository>();


builder.Services.AddClienteDependency();
builder.Services.AddRecepcionDependency();


// Dependencias de los app services //

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();