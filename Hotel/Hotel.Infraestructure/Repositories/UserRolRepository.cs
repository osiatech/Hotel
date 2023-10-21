
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

        public List<UserRol> GetUserRolsByUserRolId(int userRolId)
        {
            return this.context.UserRols.Where(ur => ur.IdUserRol == userRolId && !ur.Deleted).ToList();
        }

        public override List<UserRol> GetEntities()
        {
            return base.GetEntities().Where(rs => !rs.Deleted).ToList();
        }

    }
}
