using Hotel.API.Models.Module_RoomStatus;
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.RoomStatus;
using Hotel.Application.Exceptions;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomStatusController : ControllerBase
    {
        private readonly IRoomStatusService roomStatusService;

        public RoomStatusController(IRoomStatusService roomStatusService)
        {
            this.roomStatusService = roomStatusService;
        }


        [HttpGet("GetRoomStatuses")]
        public IActionResult Get()
        {
            var result = this.roomStatusService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetRoomStatus")]
        public IActionResult Get(int id)
        {
            var result = this.roomStatusService.GetById(id);
            {
                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
        }

        [HttpPost("SaveRoomStatus")]
        public IActionResult Post([FromBody] RoomStatusDtoAdd roomStatusDtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = roomStatusService.Save(roomStatusDtoAdd);

                if (!result.Success)
                    return BadRequest(result);

            }
            catch (RoomStatusServiceException srsex)
            {

                result.Message = srsex.Message;
                result.Success = false;
            }

            return Ok(result);
        }

        [HttpPost("UpdateRoomStatus")]
        public IActionResult Put([FromBody] RoomStatusDtoUpdate roomStatusDtoUpdate)
        {
            var result = this.roomStatusService.Update(roomStatusDtoUpdate);
            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("RemoveRoomStatus")]
        public IActionResult Remove([FromBody] RoomStatusDtoRemove roomStatusDtoRemove)
        {
            var result = this.roomStatusService.Remove(roomStatusDtoRemove);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
