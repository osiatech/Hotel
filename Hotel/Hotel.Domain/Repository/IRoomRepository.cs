using Hotel.Domain.Entities;
using System.Collections.Generic;


namespace Hotel.Domain.Repository
{
    public interface IRoomRepository
    {
        public void Save(Room room);
        public void Update(Room room);
        public void Remove(Room room);
        public List<Room> GetRooms();
        public Room GetRoom(int Id);
    }
}
