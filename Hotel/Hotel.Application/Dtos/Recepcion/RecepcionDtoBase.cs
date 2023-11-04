
using Hotel.Application.DtoBase;
using System;

namespace Hotel.Application.Dtos.Recepcion
{
    public class RecepcionDtoBase : BaseDto
    {
        public int? IdCliente { get; set; }
        public int? IdHabitacion { get; set; }
        public decimal? PrecioInicial { get; set; }
        public decimal? Adelanto { get; set; }
        public decimal? PrecioRestante { get; set; }
        public decimal? TotalPagado { get; set; }
        public decimal? CostoPenalidad { get; set; }
        public string? Observacion { get; set; }
        public bool? Estado { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
