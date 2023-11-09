using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Ioc.Dependencies
{
    public static class UsuarioDependency
    {
        public static void AddUsuarioDependency(this IServiceCollection services) 
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepositories>();
            services.AddTransient<IUsuarioService, UsuarioService>();
        }
    }
}
