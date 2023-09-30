using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public int IdCategoria { get; set; }
        public String? Descripcion { get; set; }
        public Boolean? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Deleted { get; set; }
    }
}
