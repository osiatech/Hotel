using Microsoft.AspNetCore.Mvc;
using Hotel.API.Models.Module_Piso;
using Hotel.Domain.Entities;
using Hotel.Application.Contracts;
using Hotel.Infraestructure.Repositories;
using Hotel.Application.Dtos.Piso;
using Hotel.Application.Core;
using Hotel.Application.Services;
using Hotel.Application.Dtos.Categoria;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        private readonly IPisoService pisoService;

        public PisoController(IPisoService pisoService)
        {
            this.pisoService = pisoService;
        }

        [HttpGet("GetPisoByPisoId")]
        public IActionResult GetPisoaByPisoId(int pisoId)
        {
            {
                var result = this.pisoService.GetById(pisoId);
                if (!result.Success)
                {
                    return BadRequest(result);
                }
                return Ok(result.Data);
            }
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult GetPiso()
        {
            var result = this.pisoService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

      

        [HttpPost("SavePiso")]
        public IActionResult Post([FromBody] PisoDtoAdd pisoAdd)
        {
            ServiceResult result = new ServiceResult();


            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(pisoService.Save(pisoAdd));
        }


        // POST api/<PisoController>
        [HttpPost("UpdatePiso")]
        public IActionResult Put([FromBody] PisoDtoUpdate pisoDtoUpdate)
        {
            var result = this.pisoService.Update(pisoDtoUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("RemovePiso")]
        public IActionResult Remove([FromBody] PisoDtoRemove pisoDtoRemove)
        {
            var result = this.pisoService.Remove(pisoDtoRemove);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
