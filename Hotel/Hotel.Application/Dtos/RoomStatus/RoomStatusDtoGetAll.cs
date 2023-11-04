using System;

namespace Hotel.Application.Dtos.RoomStatus
{
    public class RoomStatusDtoGetAll
    {
        public int RoomStatusId { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RegistryDate { get; set; }
    }
}
