using Hotel.Application.Core;
using Hotel.Application.Dtos.RoomStatus;


namespace Hotel.Application.Contracts
{
    public interface IRoomStatusService : IBaseService<RoomStatusDtoAdd, RoomStatusDtoUpdate, RoomStatusDtoRemove>
    {
    }
}
