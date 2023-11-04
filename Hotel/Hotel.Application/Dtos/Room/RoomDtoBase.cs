using Hotel.Application.Dtos.Base;
using System;

namespace Hotel.Application.Dtos.Room
{
    public class RoomDtoBase : DtoBase
    {
        public string? Number { get; set; }
        public string? Details { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public DateTime RegistryDate { get; set; }
    }
}
