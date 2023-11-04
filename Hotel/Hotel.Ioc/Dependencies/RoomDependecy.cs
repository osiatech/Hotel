using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Hotel.Ioc.Dependencies
{
    public static class RoomDependecy
    {
        public static void AddRoomDependecy(this IServiceCollection service)
        {
            service.AddScoped<IRoom, RoomRepository>();
            service.AddTransient<IRoomService, RoomService>();
        }
    }
}
