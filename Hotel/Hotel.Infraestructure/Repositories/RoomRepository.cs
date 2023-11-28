

using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using System.Collections.Generic;
using System.Linq;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Models;

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

            roomToUpdate.Number = entity.Number;
            roomToUpdate.Details = entity.Details;
            roomToUpdate.Price = entity.Price;
            roomToUpdate.Status = entity.Status;
            roomToUpdate.Deleted = entity.Deleted;
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
        //public RoomCategorieModel GetRoomCategorie(int Id)
        //{
        //    return this.GetRoomsCategories().SingleOrDefault(rc => rc.IdCategory == Id);
        //}

        //public List<RoomCategorieModel> GetRoomsByCategorieId(int categoryId)
        //{
        //    return this.GetRoomsCategories().Where(rc => rc.IdCategory == categoryId).ToList();
        //}

        //public List<Categorie> GetRoomByCategorie(int categoryId)
        //{
        //    return this.context.Categories.Where(rc => rc.IdCategory == categoryId
        //                                      && !rc.Deleted).ToList();
        //}

        //public List<RoomCategorieModel> GetRoomsCategories()
        //{
        //    var rooms = (from roo in this.GetEntities()
        //                   join ctg in this.context.Categories on roo.IdCategory equals ctg.IdCategory
        //                   where !roo.Deleted
        //                   select new RoomCategorieModel()
        //                   {
        //                        IdRoom = roo.IdRoom,
        //                        IdCategory = roo.IdCategory,
        //                        Number = roo.Number,
        //                        Details = roo.Details,
        //                        Price = roo.Price,
        //                        Status = roo.Status,
        //                        CreationDate = roo.CreationDate
        //                   }).ToList();


        //    return rooms;
        //}

    }
}
