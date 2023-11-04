
using Hotel.Application.DtoBase;
using Hotel.Application.Dtos.Cliente;

namespace Hotel.Application.Dtos.Recepcion
{
    public class RecepcionDtoRemove : BaseDto
    {
        public int IdRecepcion { get; set; }
        public bool Eliminado { get; set; }
    }
}
