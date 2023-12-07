using Hotel.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Room
{
    public class RoomDtoGetAll : RoomDtoBase
    {
        public int IdRoom { get; set; }
        public DateTime CreationDate { get; set; }

    }
}