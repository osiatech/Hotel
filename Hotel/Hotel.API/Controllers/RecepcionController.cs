

using Hotel.API.Modules.Recepcion;
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

        [HttpGet("Get All Recepciones")]
        public IActionResult GetClientes()
        {
            var recepciones = this.recepcionRepository.GetEntities().Select(cd => new
            RecepcionGetAllModel()
            {
                IdRecepcion = cd.IdRecepcion,
                IdCliente = cd.IdCliente,
                IdHabitacion = cd.IdHabitacion,
                FechaEntrada = cd.FechaEntrada,
                FechaSalida = cd.FechaSalida,
                FechaSalidaConfirmacion = cd.FechaSalidaConfirmacion,
                PrecioInicial = cd.PrecioInicial,
                Adelanto = cd.Adelanto,
                PrecioRestante = cd.PrecioRestante,
                TotalPagado = cd.TotalPagado,
                CostoPenalidad = cd.CostoPenalidad,
                Observacion = cd.Observacion,
                Estado = cd.Estado,
                Eliminado = cd.Eliminado
            }).ToList();
            return Ok(recepciones);
        }

        [HttpPost("Save Recepcion")]
        public IActionResult Post([FromBody] RecepcionAddModel recepcionAdd)
        {
            Recepcion recepcion = new Recepcion()
            {
                FechaRegistro = recepcionAdd.ChangeDate,
                IdUsuarioCreacion = recepcionAdd.ChangeUser,
                IdCliente = recepcionAdd.IdCliente,
                IdHabitacion = recepcionAdd.IdHabitacion,
                FechaEntrada = recepcionAdd.FechaEntrada,
                FechaSalida = recepcionAdd.FechaSalida,
                FechaSalidaConfirmacion = recepcionAdd.FechaSalidaConfirmacion,
                PrecioInicial = recepcionAdd.PrecioInicial,
                Adelanto = recepcionAdd.Adelanto,
                PrecioRestante = recepcionAdd.PrecioRestante,
                TotalPagado = recepcionAdd.TotalPagado,
                CostoPenalidad = recepcionAdd.CostoPenalidad,
                Observacion = recepcionAdd.Observacion,
                Estado = recepcionAdd.Estado,
                Eliminado = recepcionAdd.Eliminado
            };
            this.recepcionRepository.Save(recepcion);
            return Ok();
        }

        [HttpPut("Update Recepcion")]
        public IActionResult Put([FromBody] RecepcionUpdateModel recepcionUpdate)
        {
            Recepcion recepcion = new Recepcion()
            {
                IdRecepcion = recepcionUpdate.IdRecepcion,
                FechaRegistro = recepcionUpdate.ChangeDate,
                IdUsuarioCreacion = recepcionUpdate.ChangeUser,
                IdCliente = recepcionUpdate.IdCliente,
                IdHabitacion = recepcionUpdate.IdHabitacion,
                FechaEntrada = recepcionUpdate.FechaEntrada,
                FechaSalida = recepcionUpdate.FechaSalida,
                FechaSalidaConfirmacion = recepcionUpdate.FechaSalidaConfirmacion,
                PrecioInicial = recepcionUpdate.PrecioInicial,
                Adelanto = recepcionUpdate.Adelanto,
                PrecioRestante = recepcionUpdate.PrecioRestante,
                TotalPagado = recepcionUpdate.TotalPagado,
                CostoPenalidad = recepcionUpdate.CostoPenalidad,
                Observacion = recepcionUpdate.Observacion,
                Estado = recepcionUpdate.Estado,
                Eliminado = recepcionUpdate.Eliminado
            };
            this.recepcionRepository.Update(recepcion);
            return Ok();
        }
    }
}
