using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Ioc.Dependencies
{
    public static class UserRolDependecy
    {
        public static void AddUserRolDependecy(this IServiceCollection service)
        {
            service.AddScoped<IUserRol, UserRolRepository>();
            service.AddTransient<IUserRolService, UserRolService>();
        }
    }
}
