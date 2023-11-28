using Hotel.Application.Core;
using Hotel.Application.Dtos.RoomStatus;
using Hotel.Application.Exceptions;
using Microsoft.Extensions.Configuration;
using System;

namespace Hotel.Application.Extentions
{
    public static class ValidationRoomStatusExtention
    {
        public static ServiceResult IsRoomStatusValid(this RoomStatusDtoBase dtoBase, IConfiguration configuration)
        {

            ServiceResult serviceResult = new ServiceResult();


            if (string.IsNullOrEmpty(dtoBase.Description))
                throw new RoomStatusServiceException(configuration["MensajeValidaciones:estadoHabitacionDescripcion"]);

            if (dtoBase.Description.Length > 50)
                throw new RoomStatusServiceException(configuration["MensajeValidaciones:estadoHabitacionDescripcionLongitud"]);

            //if (dtoBase.IdCreationUser == 0)
            //    throw new RoomStatusServiceException(configuration["MensajeValidaciones:estadoHabitacionIdUsuarioCreacionRequerido"]);

            if (dtoBase.RegistryDate == DateTime.MinValue)
                throw new RoomStatusServiceException(configuration["MensajeValidaciones:estadoHabitacionFechaRegistroRequerido"]);

            return serviceResult;
        }
    }
}
