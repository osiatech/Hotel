using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Core
{
    public abstract class BaseEntity
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaElimino { get; set; }
        public Boolean Eliminado { get; set; }
    }
}
