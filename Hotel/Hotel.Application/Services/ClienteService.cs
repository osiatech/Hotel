
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.DtoBase.Cliente;
using Hotel.Application.Dtos.Cliente;
using Hotel.Application.Response;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hotel.Application.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository clienteRepository;
        private readonly ILogger<ClienteService> logger;

        public ClienteService(IClienteRepository clienteRepository, ILogger<ClienteService> logger)
        {
            this.clienteRepository = clienteRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {

            ServiceResult serviceResult = new ServiceResult();

            try
            {
                var clientes = this.clienteRepository.GetEntities().
                    Select(ct => new ClienteDtoGetAll()
                    {
                        IdCliente = ct.IdCliente,
                        TipoDocumento = ct.TipoDocumento,
                        Documento = ct.Documento,
                        Estado = ct.Estado,
                        Eliminado = ct.Eliminado,
                        ChangeDate = ct.FechaRegistro
                    });
                serviceResult.Data = clientes;
                serviceResult.Message = "CLIENTES OBTENIDOS EXITOSAMENTE";
            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "ERROR OBTENIENDO LOS CLIENTES.";
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
                    TipoDocumento = cliente.TipoDocumento,
                    Documento = cliente.Documento,
                    Estado = cliente.Estado,
                    Eliminado = cliente.Eliminado,
                    ChangeDate = cliente.FechaRegistro
                };
                serviceResult.Data = clienteModel;
                serviceResult.Message = "CLIENTE OBTENIDO EXITOSAMENTE.";
            }

            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "OCURRIO UN ERROR OBTENIENDO AL CLIENTE.";
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
                    FechaElimino = dtoRemove.ChangeDate,
                    IdUsuarioElimino = dtoRemove.IdUsuarioElimino
                };
                this.clienteRepository.Remove(cliente);
                serviceResult.Message = "CLIENTE REMOVIDO EXITOSAMENTE.";
            }
            catch(Exception exception)
            {
                serviceResult.Success = true;
                serviceResult.Message = "OCURRIO UN ERROR REMOVIENDO AL CLIENTE.";
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
                Cliente cliente = new Cliente()
                {
                    FechaCreacion = dtoSave.ChangeDate,
                    IdUsuarioCreacion = (int)dtoSave.IdUsuarioMod,
                    FechaRegistro = dtoSave.FechaRegistro,
                    NombreCompleto = dtoSave.NombreCompleto,
                    TipoDocumento = dtoSave.TipoDocumento,
                    Documento = dtoSave.Documento,
                    Correo = dtoSave.Correo,
                    Estado = dtoSave.Estado
                };

                this.clienteRepository.Save(cliente);

                serviceResult.Message = "CLIENTE AGREGADO EXITOSAMENTE.";

                clienteResponse.IdCliente = cliente.IdCliente;

            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "OCURRIO UN ERROR AGREGANDO AL CLIENTE.";
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }

        public ServiceResult Update(ClienteDtoUpdate dtoUpdate)
        {

            ServiceResult serviceResult = new ServiceResult();

            try
            {
                Cliente cliente = new Cliente()
                {
                    FechaRegistro = dtoUpdate.FechaRegistro,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser,
                    NombreCompleto = dtoUpdate.NombreCompleto,
                    IdCliente = dtoUpdate.IdCliente,
                };
                this.clienteRepository.Update(cliente);
                serviceResult.Message = "CLIENTE ACTUALIZADO EXITOSAMENTE.";
            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "OCURRIO UN ERROR ACTUALIZANDO AL CIENTE.";
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }
    }
}