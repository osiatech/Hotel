using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Hotel.Application.Dtos.Categoria;
using Hotel.Domain.Repository;
using Microsoft.Extensions.Configuration;
using Hotel.Application.Dtos;
using Hotel.Application.Excepctions;
using Hotel.Application.Validations;
using Hotel.Application.Response;


namespace Hotel.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository categoriaRepository;
        private readonly ILogger<ICategoriaService> logger;
        private readonly IConfiguration configuration;

        public CategoriaService(ICategoriaRepository categoriaRepository,
                                                 ILogger<CategoriaService> logger,
                                                 IConfiguration configuration)
        {
            this.categoriaRepository = categoriaRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetAll()
        {

            ServiceResult result = new ServiceResult();

            try
            {
                var categorias = this.categoriaRepository.GetEntities().Select(categoria => new CategoriaDtoGetAll()
                {
                    IdCategoria = categoria.IdCategoria,
                    FechaRegistro = categoria.FechaRegistro,
                    FechaCreacion = categoria.FechaCreacion,
                    Descripcion = categoria.Descripcion,
                    Estado = categoria.Estado

                });
                result.Success = true;
                result.Data = categorias;

            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration[$"ErrorCategoria:GetErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var categoria = this.categoriaRepository.GetEntity(id);

                CategoriaDtoGetAll categoriaModel = new CategoriaDtoGetAll()
                {
                    IdCategoria = categoria.IdCategoria,
                    FechaRegistro = categoria.FechaRegistro,
                    FechaCreacion = categoria.FechaCreacion,
                    Descripcion = categoria.Descripcion,
                    Estado = categoria.Estado
                   

                };

                result.Data = categoriaModel;
            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["ErrorCategoria:GetByIdErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;

        }

        public ServiceResult Remove(CategoriaDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Categoria categoria = new Categoria()
                {
                    IdCategoria = dtoRemove.Id,
                    Eliminado = dtoRemove.Eliminado,
                    FechaElimino = dtoRemove.ChangeDate,
                    IdUsuarioElimino = dtoRemove.ChangeUser
                };
                this.categoriaRepository.Remove(categoria);
                result.Message = this.configuration["MensajeCategoriaSucess:RemoveSucess"];

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorCategoria:AddErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(CategoriaDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            CategoriaResponse responseCategoria = new CategoriaResponse();
            try
            {

                var validresult = dtoAdd.IsCategoriaValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                Categoria categoria = new Categoria()
                {
                    IdUsuarioCreacion = dtoAdd.ChangeUser,
                    FechaCreacion = dtoAdd.FechaCreacion,
                    FechaRegistro = dtoAdd.FechaRegistro,
                    Descripcion = dtoAdd.Descripcion,
                    Estado = dtoAdd.Estado,
                    FechaMod = DateTime.Now


                };

                this.categoriaRepository.Save(categoria);
                result.Message = this.configuration["MensajeCategoriaSucess:AddSucess"];
                result.Data = categoria;

            }
            catch (CategoriaServiceException csex)
            {
                result.Success = false;
                result.Message = csex.Message;
                this.logger.LogError($"{result.Message}", csex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorCategoria:AddErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(CategoriaDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var validresult = dtoUpdate.IsCategoriaValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }
                Categoria categoria = new Categoria()
                {
                    IdCategoria = dtoUpdate.IdCategoria,
                    FechaRegistro = dtoUpdate.FechaRegistro,
                    Descripcion = dtoUpdate.Descripcion,
                    Estado = dtoUpdate.Estado,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser




                };

                this.categoriaRepository.Update(categoria);
                result.Message = this.configuration["MensajeCategoriaSucess:UpdateSucess"];


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorCategoria:UpdateErrorMessage"];
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
