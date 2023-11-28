using System;
using Hotel.Application.Core;
using Hotel.Application.Excepctions;
using Hotel.Application.Dtos.Categoria;
using Microsoft.Extensions.Configuration;
using Hotel.Application.Dtos;

namespace Hotel.Application.Validations
{
    public static class CategoriaValidations
    {
        public static ServiceResult IsCategoriaValid(this CategoriaDto categoriaDto, IConfiguration configuration)
        {
            ServiceResult serviceresult = new ServiceResult();
            if (string.IsNullOrEmpty(categoriaDto.Descripcion))
            {
                throw new CategoriaServiceException( configuration["MensajeValidaciones : categoriaDescripcionRequerido"]);
               

            }
            if (categoriaDto.Descripcion.Length > 50)
            {
                throw new CategoriaServiceException(configuration["MensajeValidaciones : categoriaDescripcionLongitud"]);
               
            }
            if (!categoriaDto.FechaRegistro.HasValue)
            {
                throw new CategoriaServiceException(configuration["MensajeValidaciones: categoriaFechaRegistroRequerido"]);
               
            }
            return serviceresult;



        }

    }
}
