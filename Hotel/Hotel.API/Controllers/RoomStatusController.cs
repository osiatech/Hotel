using Hotel.API.Models.Module_RoomStatus;
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomStatusController : ControllerBase
    {
        private readonly IRoomStatus roomStatusRepository;

        public RoomStatusController(IRoomStatus roomStatusRepository)
        {
            this.roomStatusRepository = roomStatusRepository;
        }


        [HttpGet("GetRoomStatusByRoomStatusId")]
        public IActionResult GetRoomStatusByRoomStatusId(int IdRoomStatus)
        {
            var roomStatus = this.roomStatusRepository.GetRoomStatusByRoomStatusId(IdRoomStatus);
            return Ok(roomStatus);
        }

        // GET: api/<RoomStatusController>
        [HttpGet]
        public IActionResult GetRoomsStatus()
        {
            var roomStatus = this.roomStatusRepository.GetEntities().Select(roomStatus => new RoomStatusGetAllModel()
            {
                RoomStatusId = roomStatus.IdRoomStatus,
                ChanageDate = roomStatus.CreationDate,
                ChangeUser = roomStatus.CreationUser,
                Description = roomStatus.Description,
                Status = roomStatus.Status,
                RegistryDate = roomStatus.RegistryDate
            }).ToList();

            return Ok(roomStatus);
        }

        // GET api/<RoomStatusController>/5
        [HttpGet("GetRoomStatus")]
        public IActionResult GetRoomStatus(int id)
        {
            var roomStatus = this.roomStatusRepository.GetEntity(id);
            return Ok(roomStatus);
        }

        [HttpPost("SaveRoomStatus")]
        public IActionResult Post([FromBody] RoomStatusAddModel roomStatusAdd)
        {

            RoomStatus roomStatus = new RoomStatus()
            {
                CreationDate = roomStatusAdd.ChanageDate,
                CreationUser = roomStatusAdd.ChangeUser,
                Description = roomStatusAdd.Description,
                Status = roomStatusAdd.Status,
                RegistryDate = roomStatusAdd.RegistryDate
            };

            this.roomStatusRepository.Save(roomStatus);

            return Ok();
        }

        // POST api/<RoomStatusController>
        [HttpPost("UpdateRoomStatus")]
        public IActionResult Put([FromBody] RoomStatusUpdateModel roomStatusUpdate)
        {
            RoomStatus roomStatus = new RoomStatus()
            {
                IdRoomStatus = roomStatusUpdate.RoomStatusId,
                CreationDate = roomStatusUpdate.ChanageDate,
                CreationUser = roomStatusUpdate.ChangeUser,
                Description = roomStatusUpdate.Description,
                Status = roomStatusUpdate.Status,
                RegistryDate = roomStatusUpdate.RegistryDate
            };

            this.roomStatusRepository.Update(roomStatus);

            return Ok();
        }
    }
}
