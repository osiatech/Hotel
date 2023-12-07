using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.UserRol;
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
    public class UserRolService : IUserRolService
    {
        private readonly IUserRol userRolRepository;
        private readonly ILogger<IUserRolService> logger;
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
                var userRol = this.userRolRepository.GetEntities().
                    Select(ur => new UserRolDtoGetAll()
                    {
                        CreationDate = ur.CreationDate,
                        IdUserRol = ur.IdUserRol,
                        Description = ur.Description,
                        Status = ur.Status,
                        RegistryDate = ur.RegistryDate
                    });

                result.Data = userRol;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorRolUsuario:GetErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
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
                    Description = userRol.Description,
                    Status = userRol.Status,
                    RegistryDate = userRol.RegistryDate
                };

                result.Data = userRolModel;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorRolUsuario:GetByIdErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
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
                    IdUserRol = dtoRemove.IdUserRol,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    IdUserDeleted = dtoRemove.ChangeUser
                };

                this.userRolRepository.Remove(userRol);

                result.Message = this.configuration["MensajesRolUsuarioSuccess:RemoveSuccessMessage"];
            }
            catch (Exception ex)
            {

                result.Success = true;
                result.Message = this.configuration["ErrorRolUsuario:RemoveErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Save(UserRolDtoAdd dtoAdd)
        {

            UserRolResponse result = new UserRolResponse();

            try
            {
                var validresult = dtoAdd.IsUserRolValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                UserRol userRol = new UserRol()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    IdCreationUser = dtoAdd.ChangeUser,
                    RegistryDate = dtoAdd.RegistryDate,
                    Description = dtoAdd.Description,
                    Status = dtoAdd.Status
                };

                this.userRolRepository.Save(userRol);

                result.Message = this.configuration["MensajesRolUsuarioSuccess:AddSuccessMessage"];
                result.UserRolId = userRol.IdUserRol;
            }
            catch (UserRolServiceException ursex)
            {
                result.Success = false;
                result.Message = ursex.Message;
                this.logger.LogError($"{result.Message}", ursex.ToString());

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorUsrRol:AddErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(UserRolDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var validresult = dtoUpdate.IsUserRolValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                UserRol userRol = new UserRol()
                {
                    IdUserRol = dtoUpdate.IdUserRol,
                    RegistryDate = dtoUpdate.RegistryDate,
                    Description = dtoUpdate.Description,
                    Deleted = dtoUpdate.Deleted,
                    Status = dtoUpdate.Status,
                    ModifyDate = dtoUpdate.ChangeDate,
                    IdUserModify = dtoUpdate.ChangeUser
                };

                this.userRolRepository.Update(userRol);

                result.Message = this.configuration["MensajesRolUsuarioSuccess:UpdateSuccessMessage"];
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorRolUsuario:UpdateErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
