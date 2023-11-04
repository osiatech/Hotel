
using Hotel.Application.DtoBase;
using System;

namespace Hotel.Application.Dtos.Cliente
{
    public abstract class ClienteDtoBase : BaseDto
    {
        public string? NombreCompleto { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento {  get; set; }
        public string? Correo {  get; set; }
        public bool? Estado { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
