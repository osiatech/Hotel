using Hotel.Application.Dtos.Base;

namespace Hotel.Application.Dtos.RoomStatus
{
    public class RoomStatusDtoRemove : DtoBase
    {
        public int RoomStatusId { get; set; }
        public bool Deleted { get; set; }
    }
}
