
using Hotel.Application.DtoBase;

namespace Hotel.Application.Dtos.Recepcion
{
    public class RecepcionDtoRemove : BaseDto
    {
        public int IdRecepcion { get; set; }
        public bool Eliminado { get; set; }
    }
}
