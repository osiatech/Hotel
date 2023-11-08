using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Hotel.Application.Dtos.Categoria;
using Hotel.Domain.Repository;

namespace Hotel.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository categoriaRepository;
        private readonly ILogger<ICategoriaService> logger;

        public CategoriaService(ICategoriaRepository categoriaRepository,
                                                 ILogger<CategoriaService> logger)
        {
            this.categoriaRepository = categoriaRepository;
            this.logger = logger;
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
                result.Message = $"Ocurrió un error al obtener las Categorias";
                this.logger.LogError($"{result.Message}", ex.ToString());
                
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
          ServiceResult result = new ServiceResult();
            try
            {
                var categoria = this.categoriaRepository.GetEntity(Id);

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
                result.Message = "Error al obtener la Categoria";
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
                { IdCategoria = dtoRemove.Id, Eliminado = dtoRemove.Eliminado,
                    FechaElimino=dtoRemove.ChangeDate,
                    IdUsuarioElimino = dtoRemove.ChangeUser
                };
                this.categoriaRepository.Remove(categoria);
                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al Eliminar la Categoria";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(CategoriaDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            //CategoriaResponse responseCategoria = new CategoriaResponse();
            try
            {
                Categoria categoria = new Categoria()
                {
                    IdUsuarioCreacion = dtoAdd.ChangeUser,
                   FechaCreacion = dtoAdd.FechaCreacion,
                    FechaRegistro = dtoAdd.FechaRegistro,
                    Descripcion = dtoAdd.Descripcion,
                    Estado = dtoAdd.Estado
                    
                };
               
                this.categoriaRepository.Save(categoria);
                result.Message = "Categoria Agregada Exitosamente.";
                result.Data = categoria;
                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar la Categoria";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(CategoriaDtoUpdate dtoUpdate)
        {
           ServiceResult result = new ServiceResult();
            try
            {
                Categoria categoria = new Categoria()
                {
                    IdCategoria = dtoUpdate.IdCategoria,
                    FechaCreacion = dtoUpdate.FechaCreacion,
                    Descripcion = dtoUpdate.Descripcion,
                    Estado = dtoUpdate.Estado,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser



                };

                this.categoriaRepository.Update(categoria);

                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar la Categoria";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
