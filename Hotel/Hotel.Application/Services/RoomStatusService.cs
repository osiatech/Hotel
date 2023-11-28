using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.RoomStatus;
using Hotel.Application.Exceptions;
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
    public class RoomStatusService : IRoomStatusService
    {
        private readonly IRoomStatus roomStatusRepository;
        private readonly ILogger<IRoomStatusService> logger;
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
                var roomStatus = this.roomStatusRepository.GetEntities().
                    Select(rs =>new RoomStatusDtoGetAll()
                    {
                        CreationDate = rs.CreationDate,
                        IdRoomStatus = rs.IdRoomStatus,
                        Description = rs.Description,
                        Status = rs.Status,
                        RegistryDate = rs.RegistryDate
                    });

                result.Data = roomStatus;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorEstadoHabitacion:GetErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
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
                    IdRoomStatus = roomStatus.IdRoomStatus,
                    Description = roomStatus.Description,
                    Status = roomStatus.Status,
                    RegistryDate = roomStatus.RegistryDate
                };

                result.Data = roomStatusModel;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorEstadoHabitacion:GetByIdErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
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

                result.Message = this.configuration["MensajesEstadoHabitacionSuccess:RemoveSuccessMessage"];
            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = this.configuration["ErrorEstadoHabitacion:RemoveErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Save(RoomStatusDtoAdd dtoAdd)
        {

            RoomStatusResponse result = new RoomStatusResponse();

            try
            {
                var validresult = dtoAdd.IsRoomStatusValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                RoomStatus roomStatus = new RoomStatus()
                {
                    IdRoomStatus = dtoAdd.IdRoomStatus,
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
                result.Success = false;
                result.Message = rssex.Message;
                this.logger.LogError($"{result.Message}", rssex.ToString());

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorEstadoHabitacion:AddErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }


        public ServiceResult Update(RoomStatusDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var validresult = dtoUpdate.IsRoomStatusValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

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

                result.Message = this.configuration["MensajesEstadoHabitacionSuccess:UpdateSuccessMessage"];
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorEstadoHabitacion:UpdateErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }   
}

