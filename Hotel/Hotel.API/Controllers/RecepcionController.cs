
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;
using Hotel.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionService recepcionService;

        public RecepcionController(IRecepcionService recepcionService)
        {
            this.recepcionService = recepcionService;
        }

        [HttpGet("GetAllRecepciones")]
        public IActionResult GetRecepciones()
        {
            var serviceResult = this.recepcionService.GetAll();

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpGet("GetRecepcionByRecepcionId")]
        public IActionResult GetRecepcionByRecepcionId(int IdRecepcion)
        {
            var serviceResult = this.recepcionService.GetById(IdRecepcion);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }

            return Ok(serviceResult);
        }

        [HttpGet("GetRecepcionByClienteId")]
        public ServiceResult GetRecepcionByClienteId(int clienteId)
        {
            var serviceResult = this.recepcionService.GetRecepcionByClienteId(clienteId);
            return serviceResult;
        }

        [HttpGet("GetRecepcionByHabitacionId")]
        public ServiceResult GetRecepcionByHabitacionId(int habitacionId)
        {
            var serviceResult = this.recepcionService.GetRecepcionByHabitacionId(habitacionId);
            return serviceResult;
        }

        [HttpPost("SaveRecepcion")]
        public IActionResult Post([FromBody] RecepcionDtoSave recepcionDtoSave)
        {
            //var serviceResult = this.recepcionService.Save(new Application.Dtos.Recepcion.RecepcionDtoSave() { });
            var serviceResult = this.recepcionService.Save(recepcionDtoSave);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("UpdateRecepcion")]
        public IActionResult Put([FromBody] RecepcionDtoUpdate recepcionDtoUpdate)
        {
            var serviceResult = this.recepcionService.Update(recepcionDtoUpdate);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("RemoveRecepcion")]
        public IActionResult Remove([FromBody] RecepcionDtoRemove recepcionDtoRemove)
        {
            var serviceResult = this.recepcionService.Remove(recepcionDtoRemove);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}
