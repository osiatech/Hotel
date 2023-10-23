
using Microsoft.AspNetCore.Mvc;
using Hotel.Infraestructure.Interfaces;
using Hotel.API.Models.Module_Categoria;
using Hotel.Domain.Entities;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        [HttpGet("GetCategoriaByCategoriaId")]
        public IActionResult GetCategoriaByCategoriaId(int categoriaId)
        {
            var categoria = this.categoriaRepository.GetCategoriaByCategoriaId(categoriaId);
            return Ok(categoria);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult GetCategoria()
        {
            var categorias = this.categoriaRepository.GetEntities().Select(categoria => new CategoriaGetAllModel()
            {
                CategoriaId = categoria.IdCategoria,
                ChanageDate = categoria.FechaRegistro,
                ChangeUser = categoria.IdUsuarioCreacion,
                Descripcion= categoria.Descripcion,
                Estado = categoria.Estado,
                
            }).ToList();

            return Ok(categorias);
        }

        // GET api/<CategoriaController>/5
        [HttpGet("GetCategoria")]
        public IActionResult GetCategoria(int id)
        {
            var categoria = this.categoriaRepository.GetEntity(id);
            return Ok(categoria);
        }

        [HttpPost("SaveCategoria")]
        public IActionResult Post([FromBody] CategoriaAddModel categoriaAdd)
        {

            Categoria categoria = new Categoria()
            {
              
                FechaCreacion = categoriaAdd.ChanageDate,
                IdUsuarioCreacion = categoriaAdd.ChangeUser,
                Descripcion = categoriaAdd.Descripcion,
                Estado = categoriaAdd.Estado
            };

            this.categoriaRepository.Save(categoria);

            return Ok();
        }


        // POST api/<CategoriaController>
        [HttpPost("UpdateCategoria")]
        public IActionResult Put([FromBody] CategoriaUpdateModel categoriaUpdate)
        {
            Categoria categoria = new Categoria()
            {
                IdCategoria = categoriaUpdate.CategoriaId,
                FechaCreacion = categoriaUpdate.ChanageDate,
                IdUsuarioCreacion = categoriaUpdate.ChangeUser,
                
            };

            this.categoriaRepository.Update(categoria);

            return Ok();
        }
    }
}