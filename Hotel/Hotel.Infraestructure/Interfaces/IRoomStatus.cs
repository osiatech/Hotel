

using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IRoomStatus : IBaseRepository<RoomStatus>
    {

        List<RoomStatus> GetRoomStatusByRoomStatusId(int roomStatus);

    }
}
