
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


        public RecepcionService(IRecepcionRepository recepcionRepository, ILogger<RecepcionService> logger, IConfiguration configuration)
        {
            this.recepcionRepository = recepcionRepository;
            this.logger = logger;
            this.configuration = configuration;
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
                        FechaRegistro = recepcion.FechaRegistro,
                        FechaCreacion = recepcion.FechaCreacion
                    });
                serviceResult.Data = recepciones;
                serviceResult.Message = this.configuration["Recepcion.Success.Messages:GetAll.Success.Message"];
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Recepcion.Error.Messages:GetAll.Error.Message"];
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
                    FechaEntrada = recepcion.FechaEntrada,
                    FechaSalida = recepcion.FechaSalida,
                    FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion,
                    FechaRegistro = recepcion.FechaRegistro,
                    FechaCreacion = recepcion.FechaCreacion
                };
                serviceResult.Data = recepcionModel;
                serviceResult.Message = this.configuration["Recepcion.Success.Messages:GetById.Success.Message"];
            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Recepcion.Error.Messages:GetById.Error.Message"];
                this.logger.LogError(serviceResult.Message, exception.ToString());
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
                serviceResult.Message = this.configuration["Recepcion.Success.Messages:GetRecepcionByClienteId.Success.Message"];
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Recepcion.Error.Messages:GetRecepcionByClienteId.Error.Messages"];
                this.logger.LogError(serviceResult.Message, exception.ToString());
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
                serviceResult.Message = this.configuration["Recepcion.Success.Messages:GetRecepcionByHabitacionId.Success.Message"];
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Recepcion.Error.Messages:GetRecepcionByHabitacionId.Error.Message"];
                this.logger.LogError(serviceResult.Message, exception.ToString());
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
                serviceResult.Message = this.configuration["Recepcion.Success.Messages:Remove.Success.Message"];
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Recepcion.Error.Messages:Remove.Error.Message"];
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
                    FechaEntrada = dtoSave.FechaEntrada,
                    FechaSalida = dtoSave.FechaSalida,
                    FechaSalidaConfirmacion = dtoSave.FechaSalidaConfirmacion,
                    PrecioInicial = dtoSave.PrecioInicial,
                    Observacion = dtoSave.Observacion,
                    Adelanto = dtoSave.Adelanto,
                    PrecioRestante = dtoSave.PrecioRestante,
                    TotalPagado = dtoSave.TotalPagado,
                    CostoPenalidad = dtoSave.CostoPenalidad,
                    IdUsuarioCreacion = dtoSave.IdUsuarioCreacion,
                    FechaRegistro = dtoSave.FechaRegistro,
                    FechaCreacion = dtoSave.FechaCreacion
                };

                this.recepcionRepository.Save(recepcion);

                serviceResult.Message = this.configuration["Recepcion.Success.Messages:Save.Success.Message"];

                recepcionResponse.IdRecepcion = recepcion.IdRecepcion;

            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Recepcion.Error.Messages:Save.Error.Message"];
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
                    FechaEntrada = dtoUpdate.FechaEntrada,
                    FechaSalida = dtoUpdate.FechaSalida,
                    FechaSalidaConfirmacion = dtoUpdate.FechaSalidaConfirmacion,
                    FechaRegistro = dtoUpdate.FechaRegistro,
                    FechaCreacion = dtoUpdate.FechaCreacion
                    
                };
                this.recepcionRepository.Update(recepcion);
                serviceResult.Message = this.configuration["Recepcion.Success.Messages:Update.Success.Message"];
            }
            catch (Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = this.configuration["Recepcion.Error.Messages:Update.Error.Message"];
                this.logger.LogError(serviceResult.Message, exception.ToString());
            }
            return serviceResult;
        }
    }
}