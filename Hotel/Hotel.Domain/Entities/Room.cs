using Hotel.Domain.Core;
using System;
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
        [Column("IdEstadoHabitacion")]
        public int? IdRoomStatus { get; set; }
        [Column("IdPiso")]
        public int? IdFlat { get; set; }
        [Column("IdCategoria")]
        public int? IdCategory { get; set; }
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