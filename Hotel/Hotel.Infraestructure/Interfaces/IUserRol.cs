
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IUserRol : IBaseRepository<UserRol>
    {

        List<UserRol> GetUserRolsByUserRolId(int userRol);

    }
}
