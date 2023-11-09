

using System;

namespace Hotel.Application.Dtos.Usuario
{
    public class UsuarioDtoAdd : UsuarioDto
    {
        public int UsuarioId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
