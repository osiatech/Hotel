using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Room;
using Hotel.Application.Exceptions;
using Hotel.Application.Response;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoom roomRepository;
        private readonly ILogger<IRoomService> logger;
        public RoomService(IRoom roomRepository,
                     ILogger<RoomService> logger)
        {
            this.roomRepository = roomRepository;
            this.logger = logger;
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
                        IdCategory = roo.IdCategory,
                        IdFlat = roo.IdFlat,
                        RegistryDate = roo.RegistryDate
                    });
                result.Data = rooms;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error obteniendo las habitaciones";
                this.logger.LogError(result.Message, ex.ToString());
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
                    Number = room.Number,
                    Details = room.Details,
                    Price = room.Price,
                    Status = room.Status,
                    IdRoom = room.IdRoom,
                    IdCategory = room.IdCategory,
                    IdFlat = room.IdFlat,
                    RegistryDate = room.RegistryDate

                };

                result.Data = roomModel;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error obteniendo la habitacion.";
                this.logger.LogError(result.Message, ex.ToString());
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

                result.Message = "La habitacion fue removida.";
            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = $"Ocurrió un error removiendo la habitacion.";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Save(RoomDtoAdd dtoAdd)
        {

            RoomResponse result = new RoomResponse();

            try
            {
                //if (string.IsNullOrEmpty(dtoAdd.Description))
                //    throw new RoomStatusServiceException(this.configuration["MensajeValidaciones:estadoHabitacionDescripcionLongitud"]);

                //if (dtoAdd.Description.Length > 50)
                //    throw new RoomStatusServiceException(this.configuration["MensajeValidaciones:estadoHabitacionDescripcionLongitud"]);

                //if (dtoAdd.RegistryDate == DateTime.MinValue)
                //    throw new RoomStatusServiceException(this.configuration["MensajeValidaciones:estadoHabitacionFechaRegistroRequerido"]);




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

                //result.Message = this.configuration["MensajesEstadoHabitacionSuccess:AddSuccessMessage"];
                result.RoomId = room.IdRoom;
            }
            catch (RoomServiceException rsex)
            {
                result.Success = true;
                result.Message = rsex.Message;
                this.logger.LogError(result.Message, rsex.ToString());

            }
            catch (Exception ex)
            {

                result.Success = true;
                //result.Message = this.configuration["MensajesEstadoHabitacionSuccess:AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(RoomDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                // Validaciones //




                Room room = new Room()
                {
                    IdRoom = dtoUpdate.IdRoom,
                    IdFlat = dtoUpdate.IdFlat,
                    IdCategory = dtoUpdate.IdCategory,
                    IdRoomStatus = dtoUpdate.IdRoomStatus,
                    RegistryDate = dtoUpdate.RegistryDate,
                    Details = dtoUpdate.Details,
                    Status = dtoUpdate.Status,
                    Number= dtoUpdate.Number,
                    Price= dtoUpdate.Price,
                    ModifyDate = dtoUpdate.ChangeDate,
                    IdUserModify = dtoUpdate.ChangeUser
                };

                this.roomRepository.Update(room);

                result.Message = "La habitacion fue actualizada correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = $"Ocurrió un error actualizando la habitacion.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
