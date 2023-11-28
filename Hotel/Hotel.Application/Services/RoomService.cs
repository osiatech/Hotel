using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Room;
using Hotel.Application.Exceptions;
using Hotel.Application.Extentions;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;


namespace Hotel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoom roomRepository;
        private readonly ILogger<IRoomService> logger;
        private readonly IConfiguration configuration;
        public RoomService(IRoom roomRepository,
                     ILogger<RoomService> logger, 
                     IConfiguration configuration)
        {
            this.roomRepository = roomRepository;
            this.logger = logger;
            this.configuration = configuration;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var rooms = this.roomRepository.GetEntities().
                    Select(roo => new RoomDtoGetAll()
                    {
                        Number = roo.Number,
                        Details = roo.Details,
                        Price = roo.Price,
                        Status = roo.Status,
                        IdRoom = roo.IdRoom,
                        IdFlat = roo.IdFlat,
                        RegistryDate = roo.RegistryDate
                    });

                result.Data = rooms;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorHabitacion:GetErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var room = this.roomRepository.GetEntity(Id);

                RoomDtoGetAll roomModel = new RoomDtoGetAll()
                {
                    IdRoom = room.IdRoom,
                    IdFlat = room.IdFlat,
                    Number = room.Number,
                    Details = room.Details,
                    Price = room.Price,
                    Deleted = room.Deleted,
                    Status = room.Status,
                    RegistryDate = room.RegistryDate

                };

                result.Data = roomModel;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorHabitacion:GetByIdErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(RoomDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Room room = new Room()
                {
                    IdRoom = dtoRemove.IdRoom,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    IdUserDeleted = dtoRemove.ChangeUser
                };

                this.roomRepository.Remove(room);

                result.Message = this.configuration["MensajesHabitacionSuccess:RemoveSuccessMessage"];
            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = this.configuration["ErrorHabitacion:RemoveErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Save(RoomDtoAdd dtoAdd)
        {

            ServiceResult result = new ServiceResult();

            try
            {
                var validresult = dtoAdd.IsRoomValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                Room room = new Room()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    IdCreationUser = dtoAdd.ChangeUser,
                    RegistryDate = dtoAdd.RegistryDate,
                    Details = dtoAdd.Details,
                    Status = dtoAdd.Status,
                    Number = dtoAdd.Number,
                    Price = dtoAdd.Price,
                };

                this.roomRepository.Save(room);

                result.Message = this.configuration["MensajesHabitacionSuccess:AddSuccessMessage"];

            }
            catch (RoomServiceException rsex)
            {
                result.Success = false;
                result.Message = rsex.Message;
                this.logger.LogError($"{result.Message}", rsex.ToString());

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorHabitacion:AddErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(RoomDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var validresult = dtoUpdate.IsRoomValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                Room room = new Room()
                {
                    IdRoom = dtoUpdate.IdRoom,
                    RegistryDate = dtoUpdate.RegistryDate,
                    Details = dtoUpdate.Details,
                    Status = dtoUpdate.Status,
                    Deleted = dtoUpdate.Deleted,
                    Number = dtoUpdate.Number,
                    Price = dtoUpdate.Price,
                    ModifyDate = dtoUpdate.ChangeDate,
                    IdUserModify = dtoUpdate.ChangeUser
                };

                this.roomRepository.Update(room);

                result.Message = this.configuration["MensajesHabitacionSuccess:UpdateSuccessMessage"];
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorHabitacion:UpdateErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
