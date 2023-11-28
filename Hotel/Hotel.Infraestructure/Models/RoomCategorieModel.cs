
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Infraestructure.Models
{
    public class RoomCategorieModel
    {
        [Key]
        [Column("IdHabitacion")]
        public int IdRoom { get; set; }
        [Column("IdEstadoHabitacion")]
        public int? IdCategory { get; set; }
        [Column("Numero")]
        public string? Number { get; set; }
        [Column("Detalle")]
        public string? Details { get; set; }
        [Column("Precio")]
        public decimal? Price { get; set; }
        [Column("Estado")]
        public bool? Status { get; set; }
        [Column("FechaCreacion")]
        public DateTime CreationDate { get; set; }
    }
}
