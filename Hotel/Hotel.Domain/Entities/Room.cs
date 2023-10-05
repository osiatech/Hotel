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
        public int IdRoom { get; set; }
        public string? Number { get; set; }
        public string? Details { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public DateTime RegistryDate { get; set; }
        
    }
}
