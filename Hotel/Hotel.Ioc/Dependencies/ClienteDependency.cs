
using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Ioc.Dependencies
{
    public static class ClienteDependency
    {
        public static void AddClienteDependency(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();
            serviceCollection.AddTransient<IClienteService, ClienteService>();
        }
    }
}
