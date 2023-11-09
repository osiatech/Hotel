using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Piso
{
    public class PisoDto : DtoBase
    {
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
