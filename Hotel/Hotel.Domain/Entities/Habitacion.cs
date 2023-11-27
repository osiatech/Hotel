
using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities
{
    public class Habitacion : BaseEntity
    {
        [Key]
        public int IdHabitacion { get; set; }
        public int? Numero {  get; set; }
        public string? Detalle { get; set; }
        public int? Precio { get; set; }
    }
}
