
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

        [HttpGet("GetClienteByClienteId")]
        public IActionResult GetClienteByClienteId(int id)
        {
            var serviceResult = this.clienteService.GetById(id);
           
            if(!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }

            return Ok(serviceResult);
        }

        [HttpGet("GetAllClientes")]
        public IActionResult GetClientes()
        {
            var serviceResult = this.clienteService.GetAll();

            if(!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPost("SaveCliente")]
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

        [HttpPut("UpdateCliente")]
        public IActionResult Put([FromBody] ClienteDtoUpdate clienteDtoUpdate)
        {
            var serviceResult = this.clienteService.Update(clienteDtoUpdate);

            if(!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("RemoveCliente")]
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