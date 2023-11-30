
using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Ioc.Dependencies
{
    public static class ClienteDependency
    {
        public static void AddClienteDependency(this IServiceCollection serviceCollection) //En este metodo (AddClienteDependency) se estan agregando todos los objetos del tipo IServiceCollection
        {
            serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();
            serviceCollection.AddTransient<IClienteService, ClienteService>();
        }
    }
}
