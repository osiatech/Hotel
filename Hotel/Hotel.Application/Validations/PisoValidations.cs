using System;
using Hotel.Application.Core;
using Hotel.Application.Excepctions;
using Hotel.Application.Dtos.Categoria;
using Microsoft.Extensions.Configuration;
using Hotel.Application.Dtos;
using Hotel.Application.Dtos.Piso;

namespace Hotel.Application.Validations
{
    public static class PisoValidations 
    {
        public static ServiceResult IsPisoValid(this PisoDto pisoDto, IConfiguration configuration)
        {
            ServiceResult serviceresult = new ServiceResult();
            if (string.IsNullOrEmpty(pisoDto.Descripcion))

                throw new PisoServiceException(configuration["MensajeValidaciones:pisoDescripcionRequerido"]);



            if (pisoDto.Descripcion.Length > 50)

                throw new PisoServiceException(configuration["MensajeValidaciones:pisoDescripcionLongitud"]);



            if (!pisoDto.FechaRegistro.HasValue)


                throw new PisoServiceException(configuration["MensajeValidaciones:pisoFechaRegistroRequerido"]);


            return serviceresult;



        }

    }
}
