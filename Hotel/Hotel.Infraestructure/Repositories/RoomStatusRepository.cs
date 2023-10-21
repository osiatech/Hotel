
using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using System.Collections.Generic;
using System.Linq;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;

namespace Hotel.Infraestructure.Repositories
{
    public class RoomStatusRepository : BaseRepository<RoomStatus>, IRoomStatus
    {
        private readonly HotelContext context;

        public RoomStatusRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public List<RoomStatus> GetRoomStatusByRoomStatusId(int roomStatusId)
        {
            return this.context.RoomStatus.Where(rs => rs.IdRoomStatus == roomStatusId && !rs.Deleted).ToList();
        }

        public override List<RoomStatus> GetEntities()
        {
            return base.GetEntities().Where(rs => !rs.Deleted).ToList();
        }

    }
}
