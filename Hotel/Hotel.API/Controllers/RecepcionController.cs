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
        private readonly IRecepcionRepository recepcionRepository;

        public RecepcionController(IRecepcionRepository recepcionRepository)
        {
            this.recepcionRepository = recepcionRepository;
        }

        
        [HttpGet("Get Recepcion By ClienteId")]
        public IActionResult GetRecepcionByClienteId(int IdCliente)
        {
            var recepciones = this.recepcionRepository.GetRecepcionByClienteId(IdCliente);
            return Ok(recepciones);
        }

        [HttpGet("Get Recepcion By HabitacionId")]
        public IActionResult GetRecepcionByHabitacionId(int habitacionId)
        {
            var recepciones = this.recepcionRepository.GetRecepcionByHabitacionId(habitacionId);
            return Ok(recepciones);
        }
    }
}
