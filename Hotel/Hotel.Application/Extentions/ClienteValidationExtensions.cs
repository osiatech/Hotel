
using Hotel.Application.Core;
using Hotel.Application.Dtos.Cliente;
using Hotel.Application.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Hotel.Application.Extentions
{
    //IMPORTANT: Extension classes in C# are commonly static.
    //Extension classes are typically static, but they can
    //also be non-static in certain situations.While static extension classes are
    //the most common and versatile,non-static extension classes can be
    //useful in specific scenarios.
    public static class ClienteValidationExtensions
    {
        public static ServiceResult ClienteDataValidations(this ClienteDtoBase clienteDtoBase, IConfiguration configuration)
        {
            ServiceResult serviceResult = new ServiceResult();

            if (string.IsNullOrEmpty(clienteDtoBase.NombreCompleto))
            {
                throw new ClienteServiceException(configuration["ValidationMessages:Cliente.NombreCompleto.Requerido"]);
            }

            if (clienteDtoBase.NombreCompleto.Length > 50)
            {
                throw new ClienteServiceException(configuration["ValidationMessages:Cliente.NombreCompleto.Longitud"]);
            }

            if (string.IsNullOrEmpty(clienteDtoBase.TipoDocumento))
            {
                throw new ClienteServiceException(configuration["ValidationMessages:Cliente.TipoDocumento.Requerido"]);
            }

            if (clienteDtoBase.TipoDocumento.Length > 15)
            {
                throw new ClienteServiceException(configuration["ValidationMessages:Cliente.TipoDocumento.Longitud"]);
            }

            if (string.IsNullOrEmpty(clienteDtoBase.Documento))
            {
                throw new ClienteServiceException(configuration["ValidationMessages:Cliente.Documento.Requerido"]);
            }

            if (clienteDtoBase.Documento.Length > 15)
            {
                throw new ClienteServiceException(configuration["ValidationMessages:Cliente.Documento.Longitud"]);
            }

            if (string.IsNullOrEmpty(clienteDtoBase.Correo))
            {
                throw new ClienteServiceException(configuration["ValidationMessages:Cliente.Correo.Requerido"]);
            }

            if (!clienteDtoBase.FechaRegistro.HasValue)
            {
                throw new ClienteServiceException(configuration["ValidationMessages:Cliente.FechaRegistro.Requerido"]);
            }

            if (clienteDtoBase.Correo.Length > 50)
            {
                throw new ClienteServiceException(configuration["ValidationMessages:Cliente.Correo.Longitud"]);
            }

            return serviceResult;
        }
    }
}
