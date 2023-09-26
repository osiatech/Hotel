using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class Piso
    {
        public int IdPiso { get; set; }
        public String? Descripcion { get; set; }
        public Boolean? Estado { get; set; }
        public DateTime? FechaCreacion {  get; set; }
    }
}
