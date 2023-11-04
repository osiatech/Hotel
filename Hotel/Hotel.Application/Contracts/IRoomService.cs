using Hotel.Application.Core;
using Hotel.Application.Dtos.Room;

namespace Hotel.Application.Contracts
{
    public interface IRoomService : IBaseService<RoomDtoAdd, RoomDtoUpdate, RoomDtoRemove>
    {

    }
}
