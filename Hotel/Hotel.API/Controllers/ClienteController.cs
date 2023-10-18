using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository clienteRepository) //inyecion de depencia (DIP)
        {
            this.clienteRepository = clienteRepository;
        }
   
        [HttpGet("Get Cliente By ClienteId")]
        public IActionResult GetClienteByClienteId(int clienteId)
        {
            var clientes = this.clienteRepository.GetClienteByClienteId(clienteId);
            return Ok(clientes);
        }

        //[HttpGet("Get Clientes")]
        //public IActionResult GetClientes()
        //{
            /*var clientes = this.clienteRepository.GetEntities().Select(cd => new )*/
        //}//
    }
}
