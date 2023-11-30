
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.DtoBase.Cliente;
using Hotel.Application.Dtos.Cliente;
using Hotel.Application.Response;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hotel.Application.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository clienteRepository;
        private readonly ILogger<ClienteService> logger;
        private readonly IConfiguration configuration;

        public ClienteService(IClienteRepository clienteRepository, ILogger<ClienteService> logger, IConfiguration configuration)
        {
            this.clienteRepository = clienteRepository;
            this.logger = logger;
            this.configuration = configuration;
        }

        public ServiceResult GetAll()
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                var clientes = this.clienteRepository.GetEntities().
                    Select(cliente => new ClienteDtoGetAll()
                    {
                        IdCliente = cliente.IdCliente,
                        NombreCompleto = cliente.NombreCompleto,
                        TipoDocumento = cliente.TipoDocumento,
                        Documento = cliente.Documento,
                        Correo = cliente.Correo,
                        Eliminado = cliente.Eliminado,
                        ChangeDate = cliente.FechaMod,
                        ChangeUser = cliente.IdUsuarioMod,
                        FechaRegistro = cliente.FechaRegistro,
                        FechaCreacion = cliente.FechaCreacion
                    });
                serviceResult.Data = clientes;
                serviceResult.Message = this.configuration["Cliente.Success.Messages:GetAll.Success.Message"];
            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Cliente.Error.Messages:GetAll.Error.Message"];
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                var cliente = this.clienteRepository.GetEntity(id);

                ClienteDtoGetAll clienteModel = new ClienteDtoGetAll()
                {
                    IdCliente = cliente.IdCliente,
                    NombreCompleto = cliente.NombreCompleto,
                    TipoDocumento = cliente.TipoDocumento,
                    Documento = cliente.Documento,
                    Correo = cliente.Correo,
                    Eliminado = cliente.Eliminado,
                    ChangeDate = cliente.FechaMod,
                    ChangeUser = cliente.IdUsuarioMod,
                    FechaRegistro = cliente.FechaRegistro,
                    FechaCreacion = cliente.FechaCreacion
                };
                serviceResult.Data = clienteModel;
                serviceResult.Message = this.configuration["Cliente.Success.Messages:GetById.Success.Message"];
            }

            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Cliente.Error.Messages:GetById.Error.Message"];
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }

            return serviceResult;
        }

        public ServiceResult Remove(ClienteDtoRemove dtoRemove)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                Cliente cliente = new Cliente()
                {
                    IdCliente = dtoRemove.IdCliente,
                    Eliminado = dtoRemove.Eliminado,
                    FechaElimino = dtoRemove.FechaElimino,
                    IdUsuarioElimino = dtoRemove.IdUsuarioElimino
                };
                this.clienteRepository.Remove(cliente);
                serviceResult.Message = this.configuration["Cliente.Success.Messages:Remove.Success.Message"];
            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Cliente.Error.Messages:Remove.Error.Message"];
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }

        public ServiceResult Save(ClienteDtoSave dtoSave)
        {

            ServiceResult serviceResult = new ServiceResult();

            ClienteResponse clienteResponse = new ClienteResponse();

            try
            {

                //  ************* Validaciones **************

                if(string.IsNullOrEmpty(dtoSave.NombreCompleto))
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.NombreCompleto.Requerido"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if(dtoSave.NombreCompleto.Length > 50)
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.NombreCompleto.Longitud"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if(string.IsNullOrEmpty(dtoSave.TipoDocumento))
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.TipoDocumento.Requerido"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if(dtoSave.TipoDocumento.Length > 15)
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.TipoDocumento.Longitud"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if(string.IsNullOrEmpty(dtoSave.Documento))
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.Documento.Requerido"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if(dtoSave.Documento.Length > 15)
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.Documento.Longitud"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if(string.IsNullOrEmpty(dtoSave.Correo))
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.Correo.Requerido"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if(!dtoSave.FechaRegistro.HasValue)
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.FechaRegistro.Requerido"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if(dtoSave.Correo.Length > 50)
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.Correo.Longitud"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                Cliente cliente = new Cliente()
                {   
                    NombreCompleto = dtoSave.NombreCompleto,
                    TipoDocumento = dtoSave.TipoDocumento,
                    Documento = dtoSave.Documento,
                    Correo = dtoSave.Correo,
                    Estado = dtoSave.Estado,
                    FechaCreacion = dtoSave.FechaCreacion,
                    FechaRegistro = dtoSave.FechaRegistro,
                    IdUsuarioCreacion = dtoSave.IdUsuarioCreacion,
                };

                this.clienteRepository.Save(cliente);

                serviceResult.Message = this.configuration["Cliente.Success.Messages:Save.Success.Message"];

                clienteResponse.IdCliente = cliente.IdCliente;

            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Cliente.Error.Messages:Save.Error.Message"];
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }

        public ServiceResult Update(ClienteDtoUpdate dtoUpdate)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {

                //  ************* Validaciones **************

                if (string.IsNullOrEmpty(dtoUpdate.NombreCompleto))
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.NombreCompleto.Requerido"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if (dtoUpdate.NombreCompleto.Length > 50)
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.NombreCompleto.Longitud"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if (string.IsNullOrEmpty(dtoUpdate.TipoDocumento))
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.TipoDocumento.Requerido"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if (dtoUpdate.TipoDocumento.Length > 15)
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.TipoDocumento.Longitud"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if (string.IsNullOrEmpty(dtoUpdate.Documento))
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.Documento.Requerido"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if (dtoUpdate.Documento.Length > 15)
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.Documento.Longitud"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if (string.IsNullOrEmpty(dtoUpdate.Correo))
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.Correo.Requerido"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                if (dtoUpdate.Correo.Length > 50)
                {
                    serviceResult.Message = this.configuration["ValidationMessages:Cliente.Correo.Longitud"];
                    serviceResult.Success = false;
                    return serviceResult;
                }

                Cliente cliente = new Cliente()
                {
                    IdCliente = dtoUpdate.IdCliente,
                    NombreCompleto = dtoUpdate.NombreCompleto,
                    TipoDocumento = dtoUpdate.TipoDocumento,
                    Documento = dtoUpdate.Documento,
                    Correo = dtoUpdate.Correo,
                    Eliminado = dtoUpdate.Eliminado,
                    Estado = dtoUpdate.Estado,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser
                };
                this.clienteRepository.Update(cliente);
                serviceResult.Message = this.configuration["Cliente.Success.Messages:Update.Success.Message"];
            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Cliente.Error.Messages:Update.Error.Message"];
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }
    }
}