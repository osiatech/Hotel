
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;
using Hotel.Application.Response;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hotel.Application.Services
{
    public class RecepcionService : IRecepcionService
    {

        private readonly IRecepcionRepository recepcionRepository;
        private readonly ILogger<RecepcionService> logger;

        public RecepcionService(IRecepcionRepository recepcionRepository, ILogger<RecepcionService> logger)
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
                    Select(rp => new RecepcionDtoGetAll()
                    {
                        IdRecepcion = rp.IdRecepcion,
                        IdCliente = rp.IdCliente,
                        IdHabitacion = rp.IdHabitacion,
                        FechaEntrada = rp.FechaEntrada,
                        FechaSalida = rp.FechaSalida,
                        FechaSalidaConfirmacion = rp.FechaSalidaConfirmacion,
                        PrecioInicial = rp.PrecioInicial,
                        Adelanto = rp.Adelanto,
                        PrecioRestante = rp.PrecioRestante,
                        TotalPagado = rp.TotalPagado,
                        CostoPenalidad = rp.CostoPenalidad,
                        Observacion = rp.Observacion,
                        Estado = rp.Estado,
                        Eliminado = rp.Eliminado,
                        ChangeDate = rp.FechaRegistro
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
                    FechaEntrada = recepcion.FechaEntrada,
                    FechaSalida = recepcion.FechaSalida,
                    FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion,
                    PrecioInicial = recepcion.PrecioInicial,
                    Adelanto = recepcion.Adelanto,
                    PrecioRestante = recepcion.PrecioRestante,
                    TotalPagado = recepcion.TotalPagado,
                    CostoPenalidad = recepcion.CostoPenalidad,
                    Observacion = recepcion.Observacion,
                    Estado = recepcion.Estado,
                    Eliminado = recepcion.Eliminado,
                    ChangeDate = recepcion.FechaRegistro
                };
                serviceResult.Data = recepcionModel;
                serviceResult.Message = "RECEPCION OBTENIDA EXITOSAMENTE.";

            }
            catch(Exception exception)
            {
                serviceResult.Success = false;
                serviceResult.Message = "OCURRIO UN ERROR OBTENIENDO LA RECEPCION.";
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
                    FechaElimino = dtoRemove.ChangeDate,
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
                    FechaCreacion = dtoSave.ChangeDate,
                    IdUsuarioCreacion = (int)dtoSave.IdUsuarioMod,
                    FechaRegistro = dtoSave.FechaRegistro,
                    PrecioInicial = dtoSave.PrecioInicial,
                    Adelanto = dtoSave.Adelanto,
                    PrecioRestante = dtoSave.PrecioRestante,
                    TotalPagado = dtoSave.TotalPagado,
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
                    IdCliente = dtoUpdate.IdCliente,
                    IdHabitacion = dtoUpdate.IdHabitacion,
                    FechaRegistro = dtoUpdate.FechaRegistro,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser,
                    PrecioInicial = dtoUpdate.PrecioInicial,
                    Adelanto = dtoUpdate.Adelanto
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
