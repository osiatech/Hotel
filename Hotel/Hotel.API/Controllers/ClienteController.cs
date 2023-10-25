using Hotel.API.Modules.Cliente;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetClienteByClienteId(int IdCliente)
        {
            var clientes = this.clienteRepository.GetClienteByClienteId(IdCliente);
            return Ok(clientes);
        }

        [HttpGet("Get All Clientes")]
        public IActionResult GetClientes()
        {
            var clientes = this.clienteRepository.GetEntities().Select(cd => new
            ClienteGetAllModel()
            {
                IdCliente = cd.IdCliente,
                ChangeDate = cd.FechaRegistro,
                TipoDocumento = cd.TipoDocumento,
                Documento = cd.Documento,
                NombreCompleto = cd.NombreCompleto,
                Correo = cd.Correo,
                Estado = cd.Estado,
                Eliminado = cd.Eliminado,
            }).ToList();
            return Ok(clientes);
        }


        [HttpPost("Save Cliente")]
        public IActionResult Post([FromBody] ClienteAddModel clienteAdd)
        {
            Cliente cliente = new Cliente()
            {
                FechaRegistro = clienteAdd.ChangeDate,
                IdUsuarioCreacion = clienteAdd.ChangeUser,
                TipoDocumento = clienteAdd.TipoDocumento,
                Documento = clienteAdd.Documento,
                NombreCompleto = clienteAdd.NombreCompleto,
                Correo = clienteAdd.Correo,
                Estado = clienteAdd.Estado,
                Eliminado = clienteAdd.Eliminado
            };

            this.clienteRepository.Save(cliente);
            return Ok();
        }

        [HttpPut("Update Cliente")]
        public IActionResult Put([FromBody] ClienteUpdateModel clienteUpdate)
        {
            Cliente cliente = new Cliente()
            {
                IdCliente = clienteUpdate.IdCliente,
                FechaRegistro = clienteUpdate.ChangeDate,
                IdUsuarioCreacion = clienteUpdate.ChangeUser,
                TipoDocumento = clienteUpdate.TipoDocumento,
                Documento = clienteUpdate.Documento,
                NombreCompleto = clienteUpdate.NombreCompleto,
                Correo = clienteUpdate.Correo,
                Estado = clienteUpdate.Estado,
                Eliminado = clienteUpdate.Eliminado
            };
            this.clienteRepository.Update(cliente);
            return Ok();
        }
    }  
}