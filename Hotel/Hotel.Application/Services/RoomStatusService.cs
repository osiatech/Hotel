using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.RoomStatus;
using Hotel.Application.Exceptions;
using Hotel.Application.Response;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hotel.Application.Services
{
    public class RoomStatusService : IRoomStatusService
    {
        private readonly IRoomStatus roomStatusRepository;
        private readonly ILogger<RoomStatusService> logger;
        private readonly IConfiguration configuration;

        public RoomStatusService(IRoomStatus roomStatusRepository,
                              ILogger<RoomStatusService> logger,
                              IConfiguration configuration)
        {
            this.roomStatusRepository = roomStatusRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var roomStatus = this.roomStatusRepository.GetEntities().Select(rs =>
                                                                                new RoomStatusDtoGetAll()
                                                                                {
                                                                                    CreationDate = rs.CreationDate,
                                                                                    RoomStatusId = rs.IdRoomStatus,
                                                                                    Description = rs.Description,
                                                                                    Status = rs.Status,
                                                                                    RegistryDate = rs.RegistryDate
                                                                                });
                result.Data = roomStatus;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error obteniendo los estados de las habitaciones";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var roomStatus = this.roomStatusRepository.GetEntity(Id);

                RoomStatusDtoGetAll roomStatusModel = new RoomStatusDtoGetAll()
                {
                    CreationDate = roomStatus.CreationDate,
                    RoomStatusId = roomStatus.IdRoomStatus,
                    Description = roomStatus.Description,
                    Status = roomStatus.Status,
                    RegistryDate = roomStatus.RegistryDate
                };

                result.Data = roomStatusModel;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error obteniendo el estado de la habitacion.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(RoomStatusDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                RoomStatus roomStatus = new RoomStatus()
                {
                    IdRoomStatus = dtoRemove.RoomStatusId,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    IdUserDeleted = dtoRemove.ChangeUser
                };

                this.roomStatusRepository.Remove(roomStatus);

                result.Message = "El estado de la habitacion fue removido.";
            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = $"Ocurrió un error removiendo el estado de la habitacion.";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }
        public ServiceResult Save(RoomStatusDtoAdd dtoAdd)
        {

            RoomStatusResponse result = new RoomStatusResponse();

            try
            {
                if (string.IsNullOrEmpty(dtoAdd.Description))
                    throw new RoomStatusServiceException(this.configuration["MensajeValidaciones:estadoHabitacionDescripcionLongitud"]);

                if (dtoAdd.Description.Length > 50)
                    throw new RoomStatusServiceException(this.configuration["MensajeValidaciones:estadoHabitacionDescripcionLongitud"]);

                if (dtoAdd.RegistryDate == DateTime.MinValue)
                    throw new RoomStatusServiceException(this.configuration["MensajeValidaciones:estadoHabitacionFechaRegistroRequerido"]);
            
                


                RoomStatus roomStatus = new RoomStatus()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    IdCreationUser = dtoAdd.ChangeUser,
                    RegistryDate = dtoAdd.RegistryDate,
                    Description = dtoAdd.Description,
                    Status = dtoAdd.Status
                };

                this.roomStatusRepository.Save(roomStatus);

                result.Message = this.configuration["MensajesEstadoHabitacionSuccess:AddSuccessMessage"];
                result.RoomStatusId = roomStatus.IdRoomStatus;
            }
            catch (RoomStatusServiceException rssex)
            {
                result.Success = true;
                result.Message = rssex.Message;
                this.logger.LogError(result.Message, rssex.ToString());

            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = this.configuration["MensajesEstadoHabitacionSuccess:AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(RoomStatusDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                // Validaciones //

                


                RoomStatus roomStatus = new RoomStatus()
                {
                    IdRoomStatus = dtoUpdate.RoomStatusId,
                    RegistryDate = dtoUpdate.RegistryDate,
                    Description = dtoUpdate.Description,
                    Status = dtoUpdate.Status,
                    ModifyDate = dtoUpdate.ChangeDate,
                    IdUserModify = dtoUpdate.ChangeUser
                };

                this.roomStatusRepository.Update(roomStatus);

                result.Message = "El estado de la habitacion fue actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = $"Ocurrió un error actualizando el estado de la habitacion.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }   
}

