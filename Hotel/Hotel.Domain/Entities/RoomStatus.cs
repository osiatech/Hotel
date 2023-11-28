﻿using Hotel.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Domain.Entities
{

    [Table("EstadoHabitacion")]
    public class RoomStatus : BaseEntity
    {

        [Key]
        [Column("IdEstadoHabitacion")]
        public int IdRoomStatus { get; set; }
        [Column("Descripcion")]
        public string? Description { get; set; }
        [Column("Estado")]
        public bool? Status { get; set; }
        [Column("FechaRegistro")]
        public DateTime RegistryDate { get; set; }
       
    }
}