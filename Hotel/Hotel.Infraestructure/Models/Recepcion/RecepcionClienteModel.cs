
using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Infraestructure.Models.Recepcion
{
    public class RecepcionClienteModel
    {
        [Key]
        public int? IdCliente { get; set; }
        public int IdRecepcion {  get; set; }
        public int? Adelanto { get; set; }
        public int? PrecioInicial { get; set; }
        public int? PrecioRestante { get; set; }
        public int? TotalPagado { get; set; }
        public int? CostoPenalidad { get; set; }
        public int? Observacion { get; set; }
        public bool? Estado { get; set; }
        public bool Eliminado { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
