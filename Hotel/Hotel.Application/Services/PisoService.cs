using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Hotel.Application.Dtos.Piso;
using Hotel.Domain.Repository;
using Microsoft.Extensions.Configuration;
using Hotel.Application.Response;
using Hotel.Application.Validations;

namespace Hotel.Application.Services
{
    public class PisoService : IPisoService
    {
        private readonly IPisoRepository pisoRepository;
        private readonly ILogger<IPisoService> logger;
        private readonly IConfiguration configuration;

        public PisoService(IPisoRepository pisoRepository,
                                             ILogger<PisoService> logger, IConfiguration configuration)
        {
            this.pisoRepository = pisoRepository;
            this.logger = logger;
            this.configuration = configuration;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var pisos = this.pisoRepository.GetEntities().Select(piso => new PisoDtoGetAll()
                {
                    IdPiso = piso.IdPiso,
                    FechaRegistro = piso.FechaRegistro,
                    FechaCreacion = piso.FechaCreacion,
                    Descripcion = piso.Descripcion,
                    Estado = piso.Estado

                });
                result.Success = true;
                result.Data = pisos;

            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration[$"ErrorPiso:GetErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var piso = this.pisoRepository.GetEntity(Id);

                PisoDtoGetAll pisoModel = new PisoDtoGetAll()
                {
                    IdPiso = piso.IdPiso,
                    FechaRegistro = piso.FechaRegistro,
                    FechaCreacion = piso.FechaCreacion,
                    Descripcion = piso.Descripcion,
                    Estado = piso.Estado

                };

                result.Data = pisoModel;
            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration[$"ErrorPiso:GetByIdErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(PisoDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Piso piso = new Piso()
                {
                    IdPiso = dtoRemove.Id,
                    Eliminado = dtoRemove.Eliminado,
                    FechaElimino = dtoRemove.ChangeDate,
                    IdUsuarioElimino = dtoRemove.ChangeUser
                };
                this.pisoRepository.Remove(piso);
                result.Message = this.configuration["MensajePisoSucess:RemoveSucess"];

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorPiso:AddErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(PisoDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            PisoResponse responsePiso = new PisoResponse();

            try
            {
                var validresult = dtoAdd.IsPisoValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                Piso piso = new Piso()
                {
                    IdUsuarioMod = dtoAdd.ChangeUser,
                    FechaCreacion = dtoAdd.FechaCreacion,
                    FechaRegistro = dtoAdd.FechaRegistro,
                    Descripcion = dtoAdd.Descripcion,
                    Estado = dtoAdd.Estado,
                    FechaMod = DateTime.Now


                };

                this.pisoRepository.Save(piso);
                result.Message = this.configuration["MensajePisoSucess:AddSucess"];
                result.Data = piso;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorPiso:AddErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(PisoDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var validresult = dtoUpdate.IsPisoValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                Piso piso = new Piso()
                {
                    IdPiso = dtoUpdate.IdPiso,
                    FechaRegistro = dtoUpdate.FechaRegistro,
                    Descripcion = dtoUpdate.Descripcion,
                    Estado = dtoUpdate.Estado,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser



                };

                this.pisoRepository.Update(piso);
                result.Message = this.configuration["MensajePisoSucess:UpdateSucess"];


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el Piso";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }

}

