using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Hotel.Application.Dtos.Piso;
using Hotel.Domain.Repository;


namespace Hotel.Application.Services
{
    public class PisoService : IPisoService
    {
        private readonly IPisoRepository pisoRepository;
    private readonly ILogger<IPisoService> logger;

    public PisoService(IPisoRepository pisoRepository,
                                             ILogger<PisoService> logger)
    {
        this.pisoRepository = pisoRepository;
        this.logger = logger;
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
                result.Message = $"Ocurrió un error al obtener los Pisos";
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
                result.Message = "Error al obtener el Piso";
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
                result.Message = "Piso Borrado Exitosamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al Eliminar el Piso";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(PisoDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            //PisoResponse responsePiso = new PisoResponse();
            try
            {
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
                result.Message = "Piso Agregado Exitosamente.";
                result.Data = piso;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el Piso";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(PisoDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
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
                result.Message = "Piso Actualizado Exitosamente.";


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

