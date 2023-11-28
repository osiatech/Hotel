using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Usuario
{
    public class UsuarioDtoGetAll
    {
        public int IdUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public int IdRolUsuario { get; set; }
        public string? Clave { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
