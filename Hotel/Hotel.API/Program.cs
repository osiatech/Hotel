using Hotel.API.Controllers;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Hotel.Ioc.Dependencies;
using Hotel.IOC.Dependencies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agregar dependencia del contexto //
var connectionString = builder.Configuration.GetConnectionString("HotelContext");

builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(connectionString));
// Dependencia de los repositorios //
builder.Services.AddCategoriaDependency();
builder.Services.AddPisoDependency();
builder.Services.AddUsuarioDependency();

builder.Services.AddControllers();

// Dependencia de los app services //


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
