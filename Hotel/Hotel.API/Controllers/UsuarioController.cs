using Microsoft.AspNetCore.Mvc;
using Hotel.Infraestructure.Interfaces;
using Hotel.Domain.Entities;
using Hotel.API.Models.Module_Usuario;
using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Usuario;
using Hotel.Application.Dtos.Categoria;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("GetUsuarioByUsuarioId")]
        public IActionResult GetUsuarioaByUsuarioId(int usuarioId)
        {
            var result = this.usuarioService.GetById(usuarioId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result.Data);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult GetUsuario()
        {
            var result = this.usuarioService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);

            
        }

       

        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] UsuarioDtoAdd usuarioAdd)
        {

            ServiceResult result = new ServiceResult();


            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(usuarioService.Save(usuarioAdd));
        }


        // POST api/<UsuarioController>
        [HttpPost("UpdateUsuario")]
        public IActionResult Put([FromBody] UsuarioDtoUpdate usuarioDtoUpdate)
        {
            var result = this.usuarioService.Update(usuarioDtoUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("RemoveUsuario")]
        public IActionResult Remove([FromBody] UsuarioDtoRemove usuarioDtoRemove)
        {
            var result = this.usuarioService.Remove(usuarioDtoRemove);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}