using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class Categoría
    {
        public int IdCategoria { get; set; }
        public String? Descripcion { get; set; }
        public Boolean? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
