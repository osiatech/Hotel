using Hotel.API.Models.Module_UserRol;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolController : ControllerBase
    {
        private readonly IUserRol userRolRepository;

        public UserRolController(IUserRol userRolRepository)
        {
            this.userRolRepository = userRolRepository;
        }

        [HttpGet("GetUserRolByUserRolId")]
        public IActionResult GetUserRolsByUserRolId(int userRolId)
        {
            var userRol = this.userRolRepository.GetUserRolsByUserRolId(userRolId);
            return Ok(userRol);
        }

        // GET: api/<UserRolController>
        [HttpGet]
        public IActionResult GetUserRols()
        {
            var userRols = this.userRolRepository.GetEntities().Select(userRol => new UserRolGetAllModel()
            {
                UserRolId = userRol.IdUserRol,
                ChanageDate = userRol.CreationDate,
                ChangeUser = userRol.CreationUser,
                Description = userRol.Description,
                Status = userRol.Status,
                RegistryDate = userRol.RegistryDate
            }).ToList();

            return Ok(userRols);
        }

        // GET api/<RoomController>/5
        [HttpGet("GetUserRol")]
        public IActionResult GetUserRol(int id)
        {
            var userRol = this.userRolRepository.GetEntity(id);
            return Ok(userRol);
        }

        [HttpPost("SaveUserRol")]
        public IActionResult Post([FromBody] UserRolAddModel userRolAdd)
        {

            UserRol userRol = new UserRol()
            {
                CreationDate = userRolAdd.ChanageDate,
                CreationUser = userRolAdd.ChangeUser,
                Description = userRolAdd.Description,
                Status = userRolAdd.Status,
                RegistryDate = userRolAdd.RegistryDate
            };

            this.userRolRepository.Save(userRol);

            return Ok();
        }

        // POST api/<UserRolController>
        [HttpPost("UpdateUserRol")]
        public IActionResult Put([FromBody] UserRolUpdateModel userRolUpdate)
        {
            UserRol userRol = new UserRol()
            {
                IdUserRol = userRolUpdate.UserRolId,
                CreationDate = userRolUpdate.ChanageDate,
                CreationUser = userRolUpdate.ChangeUser,
                Description = userRolUpdate.Description,
                Status = userRolUpdate.Status,
                RegistryDate = userRolUpdate.RegistryDate
            };

            this.userRolRepository.Update(userRol);

            return Ok();
        }
    }
}
