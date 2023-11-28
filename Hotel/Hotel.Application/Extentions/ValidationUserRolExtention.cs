using Hotel.Application.Core;
using Hotel.Application.Dtos.UserRol;
using Hotel.Application.Exceptions;
using Microsoft.Extensions.Configuration;
using System;

namespace Hotel.Application.Extentions
{
    public static class ValidationUserRolExtention
    {
        public static ServiceResult IsUserRolValid(this UserRolDtoBase dtoBase, IConfiguration configuration)
        {
            ServiceResult serviceResult = new ServiceResult();


            if (string.IsNullOrEmpty(dtoBase.Description))
                throw new UserRolServiceException(configuration["MensajeValidaciones:rolUsuarioDescripcionRequerido"]);

            if (dtoBase.Description.Length > 50)
                throw new UserRolServiceException(configuration["MensajeValidaciones:rolUsuarioDescripcionLongitud"]);

            if (dtoBase.IdCreationUser == 0)
                throw new UserRolServiceException(configuration["MensajeValidaciones:rolUsuarioIdUsuarioCreacionRequerido"]);

            if (dtoBase.RegistryDate == DateTime.MinValue)
                throw new UserRolServiceException(configuration["MensajeValidaciones:rolUsuarioFechaRegistroRequerido"]);

            return serviceResult;
        }
    }
}
