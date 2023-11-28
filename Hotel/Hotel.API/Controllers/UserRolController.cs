using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.UserRol;
using Hotel.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolController : ControllerBase
    {
        private readonly IUserRolService userRolService;

        public UserRolController(IUserRolService userRolService)
        {
            this.userRolService = userRolService;
        }

        [HttpGet("GetUserRols")]
        public IActionResult Get()
        {
            var result = this.userRolService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetUserRol")]
        public IActionResult Get(int id)
        {
            var result = this.userRolService.GetById(id);
            {
                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
        }

        [HttpPost("SaveUserRol")]
        public IActionResult Post([FromBody] UserRolDtoAdd userRolDtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = userRolService.Save(userRolDtoAdd);

                if (!result.Success)
                    return BadRequest(result);

            }
            catch (UserRolServiceException ursex)
            {

                result.Message = ursex.Message;
                result.Success = false;
            }

            return Ok(result);
        }

        [HttpPost("UpdateUserRol")]
        public IActionResult Put([FromBody] UserRolDtoUpdate userRolDtoUpdate)
        {
            var result = this.userRolService.Update(userRolDtoUpdate);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveUserRol")]
        public IActionResult Remove([FromBody] UserRolDtoRemove userRolDtoRemove)
        {
            var result = this.userRolService.Remove(userRolDtoRemove);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
