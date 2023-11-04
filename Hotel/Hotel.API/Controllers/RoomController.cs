
using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Core;
using Hotel.Application.Exceptions;
using Hotel.Application.Contracts;
using Hotel.Application.Dtos.Room;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }


        [HttpGet("GetRooms")]
        public IActionResult Get()
        {
            var result = this.roomService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetRoom")]
        public IActionResult Get(int id)
        {
            var result = this.roomService.GetById(id);
            {
                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
        }

        [HttpPost("SaveRoom")]
        public IActionResult Post([FromBody] RoomDtoAdd roomDtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = roomService.Save(roomDtoAdd);

                if (!result.Success)
                    return BadRequest(result);

            }
            catch (RoomServiceException rsex)
            {

                result.Message = rsex.Message;
                result.Success = false;
            }

            return Ok(result);
        }

        [HttpPost("UpdateRoom")]
        public IActionResult Put([FromBody] RoomDtoUpdate roomDtoUpdate)
        {
            var result = this.roomService.Update(roomDtoUpdate);
            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("RemoveRoom")]
        public IActionResult Remove([FromBody] RoomDtoRemove roomDtoRemove)
        {
            var result = this.roomService.Remove(roomDtoRemove);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
