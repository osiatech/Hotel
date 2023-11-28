using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Usuario;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Hotel.Domain.Repository;


namespace Hotel.Application.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<IUsuarioService> logger;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                                                 ILogger<UsuarioService> logger)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var usuarios = this.usuarioRepository.GetEntities().Select(usuario => new UsuarioDtoGetAll()
                {
                    IdUsuario = usuario.IdUsuario,
                    FechaRegistro = usuario.FechaRegistro,
                    FechaCreacion = usuario.FechaCreacion,
                    Estado = usuario.Estado,
                    NombreCompleto = usuario.NombreCompleto,
                    Correo = usuario.Correo,
                    IdRolUsuario = (int)usuario.IdRolUsuario,
                    Clave = usuario.Clave,


                });
                result.Success = true;
                result.Data = usuarios;

            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error al obtener los usuarios";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var usuario = this.usuarioRepository.GetEntity(Id);

                UsuarioDtoGetAll usuarioModel = new UsuarioDtoGetAll()
                {
                    IdUsuario = usuario.IdUsuario,
                    FechaRegistro = usuario.FechaRegistro,
                    FechaCreacion = usuario.FechaCreacion,
                    Estado = usuario.Estado,
                    NombreCompleto = usuario.NombreCompleto,
                    Correo = usuario.Correo,
                    IdRolUsuario = usuario.IdRolUsuario,
                    Clave = usuario.Clave,

                };

                result.Data = usuarioModel;
            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error al obtener el Usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(UsuarioDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
               Usuario usuario = new Usuario()
                {
                    IdUsuario = dtoRemove.Id,
                    Eliminado = dtoRemove.Eliminado,
                    FechaElimino = dtoRemove.ChangeDate,
                    IdUsuarioElimino = dtoRemove.ChangeUser
                };
                this.usuarioRepository.Remove(usuario);
                result.Message = "Usuario Borrado Exitosamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al Eliminar el Usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(UsuarioDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            //UsuarioResponse responseUsuario = new UsuarioResponse();
            try
            {
                Usuario usuario = new Usuario()
                {
                    IdUsuarioMod = dtoAdd.ChangeUser,
                    FechaCreacion = dtoAdd.FechaCreacion,
                    FechaRegistro = dtoAdd.FechaRegistro,
                    NombreCompleto = dtoAdd.NombreCompleto,
                    Estado = dtoAdd.Estado,
                    Correo = dtoAdd.Correo,
                    Clave = dtoAdd.Clave,
                    IdRolUsuario = dtoAdd.IdRolUsuario,
                    FechaMod = DateTime.Now


                };

                this.usuarioRepository.Save(usuario);
                result.Message = "Usuario agregado Exitosamente.";
                result.Data = usuario;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el Usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(UsuarioDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Usuario usuario = new Usuario()
                {
                    IdUsuario = dtoUpdate.IdUsuario,
                    FechaRegistro = dtoUpdate.FechaRegistro,
                    NombreCompleto = dtoUpdate.NombreCompleto,
                    Estado = dtoUpdate.Estado,
                    Correo = dtoUpdate.Correo,
                    Clave = dtoUpdate.Clave,
                    IdRolUsuario = dtoUpdate.IdRolUsuario,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser



                };

                this.usuarioRepository.Update(usuario);
                result.Message = "Usuario Actualizado Exitosamente.";


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el Usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }

}
    

        


