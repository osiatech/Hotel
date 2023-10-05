
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
    public class UserRolRepository : IUserRolRepository
    {
        private readonly HotelContext context;

        public UserRolRepository(HotelContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<UserRol, bool>> filter)
        {

            return this.context.UserRols.Any(filter);

        }

        public UserRol GetUserRol(int Id)
        {

            return this.context.UserRols.Find(Id);
        }

        public List<UserRol> GetUserRols()
        {

            return this.context.UserRols.Where(ur => !ur.Deleted).ToList();
        }

        public void Remove(UserRol userRol)
        {
            this.context.Remove(userRol);
        }

        public void Save(UserRol userRol)
        {
            this.context.UserRols.Add(userRol);
        }

        public void Update(UserRol userRol)
        {
            this.context.Update(userRol);
        }
    }
}
