
using Hotel.Application.Core;
using Hotel.Application.DtoBase.Cliente;
using Hotel.Application.Dtos.Cliente;
using Hotel.Application.Dtos.Recepcion;
using Hotel.Domain.Entities;
using System.Collections.Generic;

namespace Hotel.Application.Contracts
{
    public interface IRecepcionService : IBaseServices<RecepcionDtoSave, RecepcionDtoUpdate, RecepcionDtoRemove>
    {
    }
}
