
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;
using Hotel.Application.Response;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hotel.Application.Services
{
    public class RecepcionService : IRecepcionService
    {

        private readonly IRecepcionRepository recepcionRepository;
        private readonly ILogger<RecepcionService> logger;
        private readonly IConfiguration configuration;

        public RecepcionService(IRecepcionRepository recepcionRepository, ILogger<RecepcionService> logger, IClienteRepository clienteRepository)
        {
            this.recepcionRepository = recepcionRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {

            ServiceResult serviceResult = new ServiceResult();

            try
            {
                var recepciones = this.recepcionRepository.GetEntities().
                    Select(recepcion => new RecepcionDtoGetAll()
                    {
                        IdRecepcion = recepcion.IdRecepcion,
                        IdCliente = recepcion.IdCliente,
                        IdHabitacion = recepcion.IdHabitacion,
                        FechaEntrada = recepcion.FechaEntrada,
                        FechaSalida = recepcion.FechaSalida,
                        FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion,
                        PrecioInicial = recepcion.PrecioInicial,
                        Adelanto = recepcion.Adelanto,
                        PrecioRestante = recepcion.PrecioRestante,
                        TotalPagado = recepcion.TotalPagado,
                        CostoPenalidad = recepcion.CostoPenalidad,
                        Observacion = recepcion.Observacion,
                        Eliminado = recepcion.Eliminado,
                    });
                serviceResult.Data = recepciones;
                serviceResult.Message = "RECEPCIONES OBTENIDAS EXITOSAMENTE";
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "ERROR OBTENIENDO LAS RECEPCIONES.";
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                var recepcion = this.recepcionRepository.GetEntity(id);

                RecepcionDtoGetAll recepcionModel = new RecepcionDtoGetAll()
                {
                    IdRecepcion = recepcion.IdRecepcion,
                    IdCliente = recepcion.IdCliente,
                    IdHabitacion = recepcion.IdHabitacion,
                    PrecioInicial = recepcion.PrecioInicial,
                    Adelanto = recepcion.Adelanto,
                    PrecioRestante = recepcion.PrecioRestante,
                    TotalPagado = recepcion.TotalPagado,
                    CostoPenalidad = recepcion.CostoPenalidad,
                    Observacion = recepcion.Observacion,
                    Eliminado = recepcion.Eliminado,
                    FechaEntrada = recepcion.FechaEntrada,
                    FechaSalida = recepcion.FechaSalida,
                    FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion
                };
                serviceResult.Data = recepcionModel;
            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "ERROR AL OBTENER LA RECEPCION";
            }
            return serviceResult;
        }

        public ServiceResult GetRecepcionByClienteId(int clienteId)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                //var recepcion = this.context.RECEPCION.Where(rc => rc.IdCliente == clienteId).ToList();   
                var recepcion = this.recepcionRepository.GetRecepcionByClienteId(clienteId);
                serviceResult.Data = recepcion;
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "ERROR AL OBTENER LA RECEPCION";
            }
            return serviceResult;
        }

        public ServiceResult GetRecepcionByHabitacionId(int habitacionId)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                //var recepcion = this.context.RECEPCION.Where(rc => rc.IdHabitacion == habitacionId).ToList();   
                var recepcion = this.recepcionRepository.GetRecepcionByHabitacionId(habitacionId);
                serviceResult.Data = recepcion;
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "ERROR AL OBTENER LA RECEPCION";
            }
            return serviceResult;
        }

        public ServiceResult Remove(RecepcionDtoRemove dtoRemove)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                Recepcion recepcion = new Recepcion()
                {
                    IdRecepcion = dtoRemove.IdRecepcion,
                    Eliminado = dtoRemove.Eliminado,
                    FechaElimino = dtoRemove.FechaElimino,
                    IdUsuarioElimino = dtoRemove.IdUsuarioElimino
                };
                this.recepcionRepository.Remove(recepcion);
                serviceResult.Message = "RECEPCION REMOVIDA EXITOSAMENTE.";
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "OCURRIO UN ERROR REMOVIENDO LA RECEPCION.";
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }

        public ServiceResult Save(RecepcionDtoSave dtoSave)
        {
            ServiceResult serviceResult = new ServiceResult();

            RecepcionResponse recepcionResponse = new RecepcionResponse();

            try
            {
                Recepcion recepcion = new Recepcion()
                {
                    IdCliente = dtoSave.IdCliente,
                    IdHabitacion = dtoSave.IdHabitacion,
                    FechaEntrada = dtoSave.FechaEntrada,
                    FechaSalida = dtoSave.FechaSalida,
                    FechaSalidaConfirmacion = dtoSave.FechaSalidaConfirmacion,
                    FechaCreacion = dtoSave.ChangeDate,
                    IdUsuarioCreacion = dtoSave.IdUsuarioCreacion,
                    FechaRegistro = dtoSave.FechaRegistro,
                    PrecioInicial = dtoSave.PrecioInicial,
                    Observacion = dtoSave.Observacion,
                    Adelanto = dtoSave.Adelanto,
                    PrecioRestante = dtoSave.PrecioRestante,
                    TotalPagado = dtoSave.TotalPagado,
                    CostoPenalidad = dtoSave.CostoPenalidad,
                    Estado = dtoSave.Estado
                };

                this.recepcionRepository.Save(recepcion);

                serviceResult.Message = "RECEPCION AGREGADA EXITOSAMENTE.";

                recepcionResponse.IdRecepcion = recepcion.IdRecepcion;

            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "OCURRIO UN ERROR AGREGANDO LA RECEPCION.";
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }

        public ServiceResult Update(RecepcionDtoUpdate dtoUpdate)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                Recepcion recepcion = new Recepcion()
                {
                    IdRecepcion = dtoUpdate.IdRecepcion,
                    PrecioInicial = dtoUpdate.PrecioInicial,
                    Adelanto = dtoUpdate.Adelanto,
                    PrecioRestante = dtoUpdate.PrecioRestante,
                    TotalPagado = dtoUpdate.TotalPagado,
                    CostoPenalidad = dtoUpdate.CostoPenalidad,
                    Observacion = dtoUpdate.Observacion,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser,
                    Estado = dtoUpdate.Estado,
                    Eliminado = dtoUpdate.Eliminado
                };
                this.recepcionRepository.Update(recepcion);
                serviceResult.Message = "RECEPCION ACTUALIZADA EXITOSAMENTE.";
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "OCURRIO UN ERROR ACTUALIZANDO LA RECEPCION.";
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }
    }
}
