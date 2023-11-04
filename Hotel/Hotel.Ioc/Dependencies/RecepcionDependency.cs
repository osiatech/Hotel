
using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Ioc.Dependencies
{
    public static class RecepcionDependency
    {
        public static void AddRecepcionDependency(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRecepcionRepository, RecepcionRepository>();
            serviceCollection.AddTransient<IRecepcionService, RecepcionService>();
        }
    }
}
