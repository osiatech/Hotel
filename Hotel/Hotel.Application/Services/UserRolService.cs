using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.UserRol;
using Hotel.Application.Exceptions;
using Hotel.Application.Response;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Application.Services
{
    public class UserRolService : IUserRolService
    {
        private readonly IUserRol userRolRepository;
        private readonly ILogger<UserRolService> logger;
        private readonly IConfiguration configuration;

        public UserRolService(IUserRol userRolRepository,
                      ILogger<UserRolService> logger,
                      IConfiguration configuration)
        {
            this.userRolRepository = userRolRepository;
            this.logger = logger;
            this.configuration = configuration;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var userRol = this.userRolRepository.GetEntities().Select(ur =>
                                                                                new UserRolDtoGetAll()
                                                                                {
                                                                                    CreationDate = ur.CreationDate,
                                                                                    UserRolId = ur.IdUserRol,
                                                                                    Description = ur.Description,                                                    
                                                                                    Status = ur.Status,
                                                                                    RegistryDate = ur.RegistryDate
                                                                                });
                result.Data = userRol;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error obteniendo los rols de los usuarios";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var userRol = this.userRolRepository.GetEntity(Id);

                UserRolDtoGetAll userRolModel = new UserRolDtoGetAll()
                {
                    CreationDate = userRol.CreationDate,
                    UserRolId = userRol.IdUserRol,
                    Description = userRol.Description,
                    Status = userRol.Status,
                    RegistryDate = userRol.RegistryDate
                };

                result.Data = userRolModel;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error obteniendo el rol de usuario";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(UserRolDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                UserRol userRol = new UserRol()
                {
                    IdUserRol = dtoRemove.UserRolId,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    IdUserDeleted = dtoRemove.ChangeUser
                };

                this.userRolRepository.Remove(userRol);

                result.Message = "El rol de usuario fue removido.";
            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = $"Ocurrió un error removiendo el rol de usuario.";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Save(UserRolDtoAdd dtoAdd)
        {

            UserRolResponse result = new UserRolResponse();

            try
            {



                UserRol userRol = new UserRol()
                {
                    IdUserRol = dtoAdd.UserRolId,
                    CreationDate = dtoAdd.ChangeDate,
                    IdCreationUser = dtoAdd.ChangeUser,
                    RegistryDate = dtoAdd.RegistryDate,
                    Description = dtoAdd.Description,
                    Status = dtoAdd.Status
                };

                this.userRolRepository.Save(userRol);

                result.Message = this.configuration["MensajesEstdianteSuccess:AddSuccessMessage"];
                result.UserRolId = userRol.IdUserRol;
            }
            catch (UserRolServiceException ursex)
            {
                result.Success = true;
                result.Message = ursex.Message;
                this.logger.LogError(result.Message, ursex.ToString());

            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = this.configuration["MensajesEstdianteSuccess:AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(UserRolDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {






                UserRol userRol = new UserRol()
                {
                    IdUserRol = dtoUpdate.UserRolId,
                    RegistryDate = dtoUpdate.RegistryDate,
                    Description = dtoUpdate.Description,
                    Status = dtoUpdate.Status,
                    ModifyDate = dtoUpdate.ChangeDate,
                    IdUserModify = dtoUpdate.ChangeUser
                };

                this.userRolRepository.Update(userRol);

                result.Message = "El rol de usuario fue actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error actualizando el rol de usuario.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
