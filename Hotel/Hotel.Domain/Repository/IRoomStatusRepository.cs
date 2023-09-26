using Hotel.Domain.Entities;
using System.Collections.Generic;

namespace Hotel.Domain.Repository
{
    public interface IRoomStatusRepository
    {
        public void Save(RoomStatus roomStatus);
        public void Update(RoomStatus roomStatus);
        public void Remove(RoomStatus roomStatus);
        public List<RoomStatus> GetRoomStatus();
        public RoomStatus GetRoomStatus(int Id);
    }
}
