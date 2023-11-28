using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Room
{
    public class RoomDtoGetAll
    {
        public int IdRoom { get; set; }
        public int? IdRoomStatus { get; set; }
        public int? IdFlat { get; set; }
        public int IdCategory { get; set; }
        public string? Number { get; set; }
        public string? Details { get; set; }
        public decimal? Price { get; set; }
        public bool Deleted { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RegistryDate { get; set; }
    }
}
