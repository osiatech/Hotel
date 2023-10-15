﻿
using Hotel.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities
{
    
    public class Recepcion : BaseEntity
    {
        [Key]
        public int IdRecepcion {  get; set; }
        public int? IdCliente { get; set; }
        public int? IdHabitacion { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaSalidaConfirmacion { get; set; }
        public decimal? PrecioInicial { get; set; }
        public decimal? Adelanto { get; set; }
        public decimal? PrecioRestante { get; set; }
        public decimal? TotalPagado { get; set; }
        public decimal? CostoPenalidad { get; set; }
        public string? Observacion {  get; set; }
        public Boolean? Estado {  get; set; }
        public bool Eliminado { get; set; }
    }
}