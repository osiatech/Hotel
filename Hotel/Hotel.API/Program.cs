using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agregar dependencia del contexto //
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));
// Dependencia de los repositorios //
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepositories>();
builder.Services.AddTransient<IPisoRepository, PisoRepositories>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepositories>();
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
