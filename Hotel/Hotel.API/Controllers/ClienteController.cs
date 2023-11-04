
using Hotel.Application.Contracts;
using Hotel.Application.DtoBase.Cliente;
using Hotel.Application.Dtos.Cliente;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService) //inyecion de depencia (DIP)
        {
            this.clienteService = clienteService;
        }

        [HttpGet("Get Cliente By ClienteId")]
        public IActionResult GetClienteByClienteId(int IdCliente)
        {
            var serviceResult = this.clienteService.GetById(IdCliente);
           
            if(!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }

            return Ok(serviceResult);
        }

        [HttpGet("Get All Clientes")]
        public IActionResult GetClientes()
        {
            var serviceResult = this.clienteService.GetAll();

            if(!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPost("Save Cliente")]
        public IActionResult Post([FromBody] ClienteDtoSave clienteDtoSave)
        {
            //var serviceResult = this.clienteService.Save(new Application.Dtos.Cliente.ClienteDtoSave() { });
            var serviceResult = this.clienteService.Save(clienteDtoSave);

            if(!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("Update Cliente")]
        public IActionResult Put([FromBody] ClienteDtoUpdate clienteDtoUpdate)
        {
            var serviceResult = this.clienteService.Update(clienteDtoUpdate);

            if(!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("Remove Cliente")]
        public IActionResult Remove([FromBody] ClienteDtoRemove clienteDtoRemove)
        {
            var serviceResult = this.clienteService.Remove(clienteDtoRemove);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}