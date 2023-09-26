using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class Room : BaseEntity
    {
        public string? Number { get; set; }
        public string? Details { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public DateTime RegistryDate { get; set; }
        
    }
}
