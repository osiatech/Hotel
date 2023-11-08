using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Categoria
{
    public class CategoriaDtoGetAll
    {
        public int IdCategoria { get; set; }
        public String? Descripcion { get; set; }
        public Boolean? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
