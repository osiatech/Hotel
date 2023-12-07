
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

        public override void Save(RoomStatus entity)
        {
            context.RoomStatus.Add(entity);
            context.SaveChanges();
        }

        public override void Update(RoomStatus entity)
        {
            var roomStatusToUpdate = base.GetEntity(entity.IdRoomStatus);

            roomStatusToUpdate.Description = entity.Description;
            roomStatusToUpdate.Status = entity.Status;
            roomStatusToUpdate.RegistryDate = entity.RegistryDate;
            roomStatusToUpdate.ModifyDate = entity.ModifyDate;
            roomStatusToUpdate.IdUserModify = entity.IdUserModify;
            roomStatusToUpdate.Deleted = entity.Deleted;

            context.RoomStatus.Update(roomStatusToUpdate);
            context.SaveChanges();

        }

        public override void Remove(RoomStatus entity)
        {
            var roomStatusToRemove = base.GetEntity(entity.IdRoomStatus);

            roomStatusToRemove.IdRoomStatus = entity.IdRoomStatus;
            roomStatusToRemove.Deleted = entity.Deleted;
            roomStatusToRemove.DeletedDate = entity.DeletedDate;
            roomStatusToRemove.IdUserDeleted = entity.IdUserDeleted;

            this.context.RoomStatus.Update(roomStatusToRemove);
            this.context.SaveChanges();
        }

        public override List<RoomStatus> GetEntities()
        {
            return this.context.RoomStatus.Where(rs => !rs.Deleted)
                                        .OrderByDescending(rs => rs.CreationDate)
                                        .ToList();
        }

    }
}
