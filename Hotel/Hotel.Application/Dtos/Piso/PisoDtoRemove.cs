using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Piso
{
    public class PisoDtoRemove : DtoBase
    {
        public int Id { get; set; }
        public bool Eliminado { get; set; }
    }
}
