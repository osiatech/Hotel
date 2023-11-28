using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Domain.Entities
{
    public class Flat : BaseEntity
    {
        [Key]
        [Column("IdPiso")]
        public int IdFlat { get; set; }
        [Column("Descripcion")]
        public string? Description { get; set; }
        [Column("Estado")]
        public bool? Status { get; set; }
    }
}
