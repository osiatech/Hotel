
using Hotel.Domain.Core;
using System;

namespace Hotel.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public int IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo {  get; set; }
        public Boolean? Estado { get; set; }
    }
}
