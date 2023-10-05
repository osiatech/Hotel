
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IRoom : IBaseRepository<Room>
    {
        List<Room> GetRoomsByRoomId(int room);
    }
}
