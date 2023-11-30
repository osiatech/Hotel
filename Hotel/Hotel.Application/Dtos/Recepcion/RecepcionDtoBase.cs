
using Hotel.Application.DtoBase;

namespace Hotel.Application.Dtos.Recepcion
{
    public class RecepcionDtoBase : BaseDto
    {
        public decimal? PrecioInicial { get; set; }
        public decimal? Adelanto { get; set; }
        public decimal? PrecioRestante { get; set; }
        public decimal? TotalPagado { get; set; }
        public decimal? CostoPenalidad { get; set; }
        public string? Observacion { get; set; }
    }
}
