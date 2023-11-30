
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.DtoBase.Cliente;
using Hotel.Application.Dtos.Cliente;
using Hotel.Application.Extentions;
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
                //*************Validaciones************************
                var clienteDataValidations = dtoSave.ClienteDataValidations(this.configuration);

                if(!clienteDataValidations.Success)
                {
                    clienteResponse.Success = clienteDataValidations.Success;
                    clienteResponse.Message = clienteDataValidations.Message;
                    return clienteResponse;
                }
                Cliente cliente = new Cliente()
                {   
                    NombreCompleto = dtoSave.NombreCompleto,
                    TipoDocumento = dtoSave.TipoDocumento,
                    Documento = dtoSave.Documento,
                    Correo = dtoSave.Correo,
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
                //*********Validaciones********************************
                var clienteDataValidations = dtoUpdate.ClienteDataValidations(this.configuration);

                if (!clienteDataValidations.Success)
                {
                    serviceResult.Success = clienteDataValidations.Success;
                    serviceResult.Message = clienteDataValidations.Message;
                    return serviceResult;
                }

                Cliente cliente = new Cliente()
                {
                    IdCliente = dtoUpdate.IdCliente,
                    NombreCompleto = dtoUpdate.NombreCompleto,
                    TipoDocumento = dtoUpdate.TipoDocumento,
                    Documento = dtoUpdate.Documento,
                    Correo = dtoUpdate.Correo,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser,
                    FechaRegistro = dtoUpdate.FechaRegistro
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