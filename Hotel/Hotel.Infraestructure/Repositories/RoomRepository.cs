

using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using System.Collections.Generic;
using System.Linq;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;

namespace Hotel.Infraestructure.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoom
    {
        private readonly HotelContext context;

        public RoomRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public List<Room> GetRoomsByRoomId(int roomId)
        {
            return this.context.Rooms.Where(roo => roo.IdRoom == roomId && !roo.Deleted).ToList();
        }

        public override List<Room> GetEntities()
        {
            return base.GetEntities().Where(roo => !roo.Deleted).ToList();
        }

    }
}
