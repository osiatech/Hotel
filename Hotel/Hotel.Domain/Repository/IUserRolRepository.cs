using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Repository
{
    public interface IUserRolRepository
    {
        public void Save(UserRol userRol);
        public void Update(UserRol userRol);
        public void Remove(UserRol userRol);
        public List<UserRol> GetUserRols();
        public UserRol GetUserRol(int Id);
    }
}
