

using Hotel.API.Modules.Recepcion;
using Hotel.Application.Contracts;
using Hotel.Application.DtoBase.Cliente;
using Hotel.Application.Dtos.Cliente;
using Hotel.Application.Dtos.Recepcion;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
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
        
        [HttpGet("Get Recepcion By ClienteId")]
        public IActionResult GetRecepcionByClienteId(int IdCliente)
        {
            var serviceResult = this.recepcionService.GetById(IdCliente);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }

            return Ok(serviceResult);
        }

        [HttpGet("Get Recepcion By HabitacionId")]
        public IActionResult GetRecepcionByHabitacionId(int habitacionId)
        {
            var serviceResult = this.recepcionService.GetById(habitacionId);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }

            return Ok(serviceResult);
        }

        [HttpGet("Get All Recepciones")]
        public IActionResult GetClientes()
        {
            var serviceResult = this.recepcionService.GetAll();

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPost("Save Recepcion")]
        public IActionResult Post([FromBody] RecepcionDtoSave recepcionDtoSave)
        {
            //var serviceResult = this.recepcionService.Save(new Application.Dtos.Recepcion.RecepcionDtoSave() { });
            var serviceResult = this.recepcionService.Save(recepcionDtoSave);

            if (serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("Update Recepcion")]
        public IActionResult Put([FromBody] RecepcionDtoUpdate recepcionDtoUpdate)
        {
            var serviceResult = this.recepcionService.Update(recepcionDtoUpdate);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("Remove Recepcion")]
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
