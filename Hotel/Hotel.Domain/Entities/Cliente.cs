
using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        [Key]
        public int IdCliente { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo {  get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public bool? Estado { get; set; }
        public bool Eliminado { get; set; }
    }
}
