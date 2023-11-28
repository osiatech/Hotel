using Hotel.Domain.Core;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        [Column("IdCategoria")]
        public int IdCategory { get; set; }
        [Column("Descripcion")]
        public string? Description { get; set; }
        [Column("Estado")]
        public bool? Status { get; set; }
    }
}
