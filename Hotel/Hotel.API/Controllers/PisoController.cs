using Microsoft.AspNetCore.Mvc;
using Hotel.Infraestructure.Interfaces;
using Hotel.Domain.Entities;
using Hotel.API.Models.Module_Piso;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        private readonly IPisoRepository pisoRepository;

        public PisoController(IPisoRepository pisoRepository)
        {
            this.pisoRepository = pisoRepository;
        }

        [HttpGet("GetPisoByPisoId")]
        public IActionResult GetPisoaByPisoId(int pisoId)
        {
            var piso = this.pisoRepository.GetPisoByPisoId(pisoId);
            return Ok(piso);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult GetPiso()
        {
            var piso = this.pisoRepository.GetEntities().Select(piso => new PisoGetAllModel()
            {
                PisoId = piso.IdPiso,
                ChanageDate = piso.FechaRegistro,
                ChangeUser = piso.IdUsuarioCreacion,
                Descripcion = piso.Descripcion,
                Estado = piso.Estado,

            }).ToList();

            return Ok(piso);
        }

        // GET api/<CategoriaController>/5
        [HttpGet("GetPiso")]
        public IActionResult GetPiso(int id)
        {
            var piso = this.pisoRepository.GetEntity(id);
            return Ok(piso);
        }

        [HttpPost("SavePiso")]
        public IActionResult Post([FromBody] PisoAddModel pisoAdd)
        {

            Piso piso = new Piso()
            {

                FechaCreacion = pisoAdd.ChanageDate,
                IdUsuarioCreacion = pisoAdd.ChangeUser,
                Descripcion = pisoAdd.Descripcion,
                Estado = pisoAdd.Estado
            };

            this.pisoRepository.Save(piso);

            return Ok();
        }


        // POST api/<PisoController>
        [HttpPost("UpdatePiso")]
        public IActionResult Put([FromBody] PisoUpdateModel pisoUpdate)
        {
            Piso piso = new Piso()
            {
                IdPiso = pisoUpdate.PisoId,
                FechaCreacion = pisoUpdate.ChanageDate,
                IdUsuarioCreacion = pisoUpdate.ChangeUser,

            };

            this.pisoRepository.Update(piso);

            return Ok();
        }
    }
}
