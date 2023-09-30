using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class Piso : BaseEntity
    {
        public int IdPiso { get; set; }
        public String? Descripcion { get; set; }
        public Boolean? Estado { get; set; }
        public DateTime? FechaCreacion {  get; set; }
        public bool Deleted { get; set; }
    }
}
