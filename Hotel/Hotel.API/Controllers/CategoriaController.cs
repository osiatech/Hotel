using Microsoft.AspNetCore.Mvc;
using Hotel.API.Models.Module_Categoria;
using Hotel.Domain.Entities;
using Hotel.Application.Contracts;
using Hotel.Infraestructure.Repositories;
using Hotel.Application.Dtos.Categoria;
using Hotel.Application.Core;
using Hotel.Application.Excepctions;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet("GetCategoriaByCategoriaId")]
        public IActionResult Get(int categoriaId)
        {
            var result = this.categoriaService.GetById(categoriaId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result.Data);
        }

      

        // GET api/<CategoriaController>/5
        [HttpGet("GetCategoria")]
        public IActionResult GetCategoria()
        {
            var result = this.categoriaService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("SaveCategoria")]
        public IActionResult Post([FromBody] CategoriaDtoAdd categoriaAdd)
        {



            ServiceResult result = new ServiceResult();

            try
            {
                result = categoriaService.Save(categoriaAdd);

                if (!result.Success)
                    return BadRequest(result);

            }
            catch (CategoriaServiceException csex)
            {

                result.Message = csex.Message;
                result.Success = false;
            }
            return Ok(result);
        }
        // POST api/<CategoriaController>
        [HttpPut("UpdateCategoria")]
        public IActionResult Put([FromBody] CategoriaDtoUpdate categoriaDtoUpdate)
        {
            var result = this.categoriaService.Update(categoriaDtoUpdate);

            if (!result.Success)
            
                return BadRequest(result);
            
            return Ok(result);
        }
        [HttpPost("RemoveCategoria")]
        public IActionResult Remove([FromBody] CategoriaDtoRemove categoriaDtoRemove)
        {
            var result = this.categoriaService.Remove(categoriaDtoRemove);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}