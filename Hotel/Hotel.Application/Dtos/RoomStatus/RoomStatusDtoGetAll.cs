using System;

namespace Hotel.Application.Dtos.RoomStatus
{
    public class RoomStatusDtoGetAll : RoomStatusDtoBase
    {
        public int IdRoomStatus { get; set; }
        public DateTime CreationDate { get; set; }

    }
}