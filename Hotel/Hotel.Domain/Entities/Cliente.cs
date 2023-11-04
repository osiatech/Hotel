
using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities
{
    public class Cliente : Person
    {
        [Key]
        public int IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public bool? Estado { get; set; }
        public bool Eliminado { get; set; }
    }
}
