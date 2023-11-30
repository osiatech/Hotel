
using Hotel.Application.DtoBase;
using System;

namespace Hotel.Application.Dtos.Recepcion
{
    public class RecepcionDtoRemove : BaseDto
    {
        public int IdRecepcion { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
