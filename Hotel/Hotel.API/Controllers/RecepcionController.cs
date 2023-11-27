

using Hotel.Application.Contracts;
using Hotel.Application.Dtos.Recepcion;
using Hotel.Application.Services;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionService recepcionService;
        private readonly RecepcionService recepcionService2;
        private readonly HotelContext context;

        public RecepcionController(IRecepcionService recepcionService, HotelContext context)
        {
            this.recepcionService = recepcionService;
            this.context = context;
        }
       

        [HttpGet("Get All Recepciones")]
        public IActionResult GetRecepciones()
        {
            var serviceResult = this.recepcionService.GetAll();

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpGet("Get Recepcion By RecepcionId")]
        public IActionResult GetRecepcionByRecepcionId(int IdRecepcion)
        {
            var serviceResult = this.recepcionService.GetById(IdRecepcion);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }

            return Ok(serviceResult);
        }

        [HttpGet("Get Recepcion by ClienteId")]
        public List<Recepcion> GetRecepcionByClienteId(int clienteId)
        {
            var recepcion = this.context.RECEPCION.Where(rc => rc.IdCliente == clienteId).ToList();
            return recepcion;
        }

        [HttpGet("Get Recepcion by HabitacionId")]
        public List<Recepcion> GetRecepcionByHabitacionId(int habitacionId)
        {
            var recepciones = this.context.RECEPCION.Where(rh => rh.IdHabitacion == habitacionId).ToList();
            return recepciones;
        }
        [HttpPost("Save Recepcion")]
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
