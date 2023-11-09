using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Ioc.Dependencies
{
    public static class PisoDependency
    {
        public static void AddPisoDependency(this IServiceCollection services)
        {
            services.AddScoped<IPisoRepository, PisoRepositories>();
            services.AddTransient<IPisoService, PisoService>();



        }
    }
}
