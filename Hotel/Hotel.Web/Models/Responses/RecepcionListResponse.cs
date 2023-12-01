﻿
namespace Hotel.Web.Models.Responses
{
    public class RecepcionListResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<RecepcionViewResponse> Data { get; set; }
    }
    
    public class RecepcionViewResponse
    {
        public int IdRecepcion { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaSalidaConfirmacion { get; set; }
        public decimal? PrecioInicial { get; set; }
        public decimal? Adelanto { get; set; }
        public decimal? PrecioRestante { get; set; }
        public decimal? TotalPagado { get; set; }
        public decimal? CostoPenalidad { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
