

using Microsoft.EntityFrameworkCore;
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hotel.Infraestructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext context;

        public RoomRepository(HotelContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Room, bool>> filter)
        {

            return this.context.Rooms.Any(filter);

        }

        public Room GetRoom(int Id)
        {

            return this.context.Rooms.Find(Id);
        }

        public List<Room> GetRooms()
        {

            return this.context.Rooms.Where(rm => !rm.Deleted).ToList();
        }

        public void Remove(Room room)
        {
            this.context.Remove(room);
        }

        public void Save(Room room)
        {
            this.context.Rooms.Add(room);
        }

        public void Update(Room room)
        {
            this.context.Update(room);
        }
    }
}
