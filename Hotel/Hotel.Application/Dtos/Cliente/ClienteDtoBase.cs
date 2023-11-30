
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
        public DateTime? FechaRegistro { get; set; }
    }
}
