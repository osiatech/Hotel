
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;


namespace Hotel.Application.Contracts
{
    public interface IRecepcionService : IBaseServices<RecepcionDtoSave, RecepcionDtoUpdate, RecepcionDtoRemove>
    {
    }
}
