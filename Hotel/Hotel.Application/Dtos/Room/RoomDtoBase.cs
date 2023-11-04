using Hotel.Application.Dtos.Base;
using System;

namespace Hotel.Application.Dtos.Room
{
    public class RoomDtoBase : DtoBase
    {
        public int? IdRoomStatus { get; set; }
        public int? IdFlat { get; set; }
        public int? IdCategory { get; set; }
        public string? Number { get; set; }
        public string? Details { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public DateTime RegistryDate { get; set; }
    }
}
