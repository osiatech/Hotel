using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Domain.Entities
{
    [Table("Habitacion")]
    public class Room : BaseEntity
    {
        [Key]
        [Column("IdHabitacion")]
        public int IdRoom { get; set; }
        [Column("Numero")]
        public string? Number { get; set; }
        [Column("Detalle")]
        public string? Details { get; set; }
        [Column("Precio")]
        public decimal? Price { get; set; }
        [Column("Estado")]
        public bool? Status { get; set; }
        [Column("FechaRegistro")]
        public DateTime RegistryDate { get; set; }
        
    }
}
