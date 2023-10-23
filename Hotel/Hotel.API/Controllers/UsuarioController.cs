using Microsoft.AspNetCore.Mvc;
using Hotel.Infraestructure.Interfaces;
using Hotel.Domain.Entities;
using Hotel.API.Models.Module_Usuario;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        [HttpGet("GetUsuarioByUsuarioId")]
        public IActionResult GetUsuarioaByUsuarioId(int usuarioId)
        {
            var usuario = this.usuarioRepository.GetUsuarioByUsuarioId(usuarioId);
            return Ok(usuario);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult GetUsuario()
        {
            var usuario = this.usuarioRepository.GetEntities().Select(usuario => new UsuarioGetAllModel()
            {
                UsuarioId = usuario.IdUsuario,
                ChanageDate = usuario.FechaRegistro,
                ChangeUser = usuario.IdUsuarioCreacion,
                NombreCompleto = usuario.NombreCompleto,
                Estado = usuario.Estado,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                IdRolUsuario = usuario.IdRolUsuario,
                

            }).ToList();

            return Ok(usuario);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("GetUsuario")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = this.usuarioRepository.GetEntity(id);
            return Ok(usuario);
        }

        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] UsuarioAddModel usuarioAdd)
        {

            Usuario usuario = new Usuario()
            {

                FechaCreacion = usuarioAdd.ChanageDate,
                IdUsuarioCreacion = usuarioAdd.ChangeUser,
                NombreCompleto = usuarioAdd.NombreCompleto,
                Estado = usuarioAdd.Estado,
                Correo = usuarioAdd.Correo,
                Clave = usuarioAdd.Clave,
                IdRolUsuario = usuarioAdd.IdRolUsuario,
            };

            this.usuarioRepository.Save(usuario);

            return Ok();
        }


        // POST api/<UsuarioController>
        [HttpPost("UpdateUsuario")]
        public IActionResult Put([FromBody] UsuarioUpdateModel usuarioUpdate)
        {
            Usuario usuario = new Usuario()
            {
                IdUsuario = usuarioUpdate.UsuarioId,
                FechaCreacion = usuarioUpdate.ChanageDate,
                IdUsuarioCreacion = usuarioUpdate.ChangeUser,

            };

            this.usuarioRepository.Update(usuario);

            return Ok();
        }
    }
}