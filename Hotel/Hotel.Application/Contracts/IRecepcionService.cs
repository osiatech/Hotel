
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;
using Hotel.Application.Services;
using Hotel.Domain.Entities;
using System.Collections.Generic;

namespace Hotel.Application.Contracts
{
    public interface IRecepcionService : IBaseServices<RecepcionDtoSave, RecepcionDtoUpdate, RecepcionDtoRemove>
    {
        public ServiceResult GetRecepcionByClienteId(int clinteId);
        public ServiceResult GetRecepcionByHabitacionId(int habitacionId);
    }
}
