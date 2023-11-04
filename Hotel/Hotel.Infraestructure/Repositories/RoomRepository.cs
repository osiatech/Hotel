

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

        public override void Save(Room entity)
        {
            context.Rooms.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Room entity)
        {
            var roomToUpdate = base.GetEntity(entity.IdRoom);

            roomToUpdate.Details = entity.Details;
            roomToUpdate.Status = entity.Status;
            roomToUpdate.RegistryDate = entity.RegistryDate;
            roomToUpdate.ModifyDate = entity.ModifyDate;
            roomToUpdate.IdUserModify = entity.IdUserModify;

            context.Rooms.Update(roomToUpdate);
            context.SaveChanges();

        }

        public override void Remove(Room entity)
        {
            var roomToRemove = base.GetEntity(entity.IdRoom);

            roomToRemove.IdRoom = entity.IdRoom;
            roomToRemove.Deleted = entity.Deleted;
            roomToRemove.DeletedDate = entity.DeletedDate;
            roomToRemove.IdUserDeleted = entity.IdUserDeleted;

            this.context.Rooms.Update(roomToRemove);
            this.context.SaveChanges();
        }
        public override List<Room> GetEntities()
        {
            return this.context.Rooms.Where(roo => !roo.Deleted)
                                        .OrderByDescending(roo => roo.CreationDate)
                                        .ToList();
        }

    }
}
