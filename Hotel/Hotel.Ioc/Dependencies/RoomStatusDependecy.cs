using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Hotel.Ioc.Dependencies
{
    public static class RoomStatusDependecy
    {
        public static void AddRoomStatusDependecy(this IServiceCollection service)
        {
            service.AddScoped<IRoomStatus, RoomStatusRepository>();
            service.AddTransient<IRoomStatusService, RoomStatusService>();
        }
    }
}
