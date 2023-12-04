using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Categoria
{
    public class CategoriaDto : DtoBase
    {
        public DateTime? FechaRegistro { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public int? idCategoria { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
