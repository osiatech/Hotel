using Hotel.Application.Core;
using Hotel.Application.Dtos.Room;
using Hotel.Application.Exceptions;
using Microsoft.Extensions.Configuration;
using System;

namespace Hotel.Application.Extentions
{
    public static class ValidationRoomExtention
    {
        public static ServiceResult IsRoomValid(this RoomDtoBase dtoBase, IConfiguration configuration)
        {

            ServiceResult serviceResult = new ServiceResult();

            if (string.IsNullOrEmpty(dtoBase.Number))
                throw new RoomServiceException(configuration["MensajeValidaciones:habitacionNumeroRequerido"]);

            if (string.IsNullOrEmpty(dtoBase.Details))
                throw new RoomServiceException(configuration["MensajeValidaciones:habitacionDetalleRequerido"]);

            if (dtoBase.Details.Length > 50)
                throw new RoomServiceException(configuration["MensajeValidaciones:habitacionDetalleLongitud"]);

            if (dtoBase.Price == 0)
                throw new RoomServiceException(configuration["MensajeValidaciones:habitacionPrecioRequerido"]);

            //if (dtoBase.IdCreationUser == 0)
            //    throw new RoomServiceException(configuration["MensajeValidaciones:habitacionIdUsuarioCreacionRequerido"]);

            if (dtoBase.RegistryDate == DateTime.MinValue)
                throw new RoomServiceException(configuration["MensajeValidaciones:habitacionFechaRegistroRequerido"]);

            return serviceResult;
        }
    }
}
