
using Microsoft.EntityFrameworkCore.Internal;
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Hotel.Infraestructure.Repositories
{
    public class RoomStatusRepository : IRoomStatusRepository
    {
        private readonly HotelContext context;

        public RoomStatusRepository(HotelContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<RoomStatus, bool>> filter)
        {

            return this.context.RoomStatus.Any(filter);

        }

        public RoomStatus GetRoomStatus(int Id)
        {

            return this.context.RoomStatus.Find(Id);
        }

        public List<RoomStatus> GetRoomStatus()
        {

            return this.context.RoomStatus.Where(rms => !rms.Deleted).ToList();
        }

        public void Remove(RoomStatus roomStatus)
        {
            this.context.Remove(roomStatus);
        }

        public void Save(RoomStatus roomStatus)
        {
            this.context.RoomStatus.Add(roomStatus);
        }

        public void Update(RoomStatus roomStatus)
        {
            this.context.Update(roomStatus);
        }
    }
}
