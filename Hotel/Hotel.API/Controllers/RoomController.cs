
using Hotel.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Hotel.Infraestructure.Interfaces;
using Hotel.API.Models.Module_Room;


namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoom roomRepository;

        public RoomController(IRoom roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        [HttpGet("GetRoomsByRoomId")]
        public IActionResult GetRoomsByRoomId(int roomId)
        {
            var rooms = this.roomRepository.GetRoomsByRoomId(roomId);
            return Ok(rooms);
        }

        // GET: api/<RoomController>
        [HttpGet]
        public IActionResult GetRooms()
        {
            var rooms = this.roomRepository.GetEntities().Select(room => new RoomGetAllModel()
            {
                RoomId = room.IdRoom,
                ChanageDate = room.CreationDate,
                ChangeUser = room.CreationUser,
                Number = room.Number,
                Details = room.Details,
                Price = room.Price,
                Status = room.Status,
                RegistryDate = room.RegistryDate
            }).ToList();

            return Ok(rooms);
        }

        // GET api/<RoomController>/5
        [HttpGet("GetRoom")]
        public IActionResult GetRoom(int id)
        {
            var room = this.roomRepository.GetEntity(id);
            return Ok(room);
        }

        [HttpPost("SaveRoom")]
        public IActionResult Post([FromBody] RoomAddModel roomAdd)
        {

            Room room = new Room()
            {
                CreationDate = roomAdd.ChanageDate,
                CreationUser = roomAdd.ChangeUser,
                Number = roomAdd.Number,
                Details = roomAdd.Details,
                Price = roomAdd.Price,
                Status = roomAdd.Status,
                RegistryDate = roomAdd.RegistryDate
            };

            this.roomRepository.Save(room);

            return Ok();
        }


        // POST api/<RoomController>
        [HttpPost("UpdateRoom")]
        public IActionResult Put([FromBody] RoomUpdateModel roomUpdate)
        {
            Room room = new Room()
            {
                IdRoom = roomUpdate.RoomId,
                CreationDate = roomUpdate.ChanageDate,
                CreationUser = roomUpdate.ChangeUser,
                Number = roomUpdate.Number,
                Details = roomUpdate.Details,
                Price = roomUpdate.Price,
                Status = roomUpdate.Status,
                RegistryDate = roomUpdate.RegistryDate
            };

            this.roomRepository.Update(room);

            return Ok();
        }
    }
}
