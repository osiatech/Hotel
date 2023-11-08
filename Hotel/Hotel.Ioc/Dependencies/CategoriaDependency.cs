using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Hotel.IOC.Dependencies
{
    public static class PisoDependency
    {
        public static void AddCategoriaDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepositories>();
            services.AddTransient<ICategoriaService, CategoriaService>();



        }

    }
}