
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infraestructure.Context;
using System.Collections.Generic;
using System.Linq;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;

namespace Hotel.Infraestructure.Repositories
{
    public class UserRolRepository : BaseRepository<UserRol>, IUserRol
    {
        private readonly HotelContext context;

        public UserRolRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public override void Save(UserRol entity)
        {
            context.UserRols.Add(entity);
            context.SaveChanges();
        }

        public override void Update(UserRol entity)
        {
            var userRolToUpdate = base.GetEntity(entity.IdUserRol);

            userRolToUpdate.Description = entity.Description;
            userRolToUpdate.Deleted = entity.Deleted;
            userRolToUpdate.Status = entity.Status;
            userRolToUpdate.RegistryDate = entity.RegistryDate;
            userRolToUpdate.ModifyDate = entity.ModifyDate;
            userRolToUpdate.IdUserModify = entity.IdUserModify;

            context.UserRols.Update(userRolToUpdate);
            context.SaveChanges();

        }

        public override void Remove(UserRol entity)
        {
            var userRolToRemove = base.GetEntity(entity.IdUserRol);

            userRolToRemove.IdUserRol = entity.IdUserRol;
            userRolToRemove.Deleted = entity.Deleted;
            userRolToRemove.DeletedDate = entity.DeletedDate;
            userRolToRemove.IdUserDeleted = entity.IdUserDeleted;

            this.context.UserRols.Update(userRolToRemove);
            this.context.SaveChanges();
        }

        public override List<UserRol> GetEntities()
        {
            return this.context.UserRols.Where(ur => !ur.Deleted)
                                        .OrderByDescending(ur => ur.CreationDate)
                                        .ToList();
        }
    }
}
