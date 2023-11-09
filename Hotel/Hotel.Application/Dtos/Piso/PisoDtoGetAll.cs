using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Piso
{
    public class PisoDtoGetAll
    {
        public int IdPiso{ get; set; }
        public String? Descripcion { get; set; }
        public Boolean? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
