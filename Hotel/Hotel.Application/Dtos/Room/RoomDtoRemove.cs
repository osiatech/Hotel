using Hotel.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Room
{
    public class RoomDtoRemove : DtoBase
    {
        public int IdRoom { get; set; }
        public bool Deleted { get; set; }
    }
}
