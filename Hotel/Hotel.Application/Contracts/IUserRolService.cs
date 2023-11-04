using Hotel.Application.Core;
using Hotel.Application.Dtos.UserRol;

namespace Hotel.Application.Contracts
{
    public interface IUserRolService : IBaseService<UserRolDtoAdd, UserRolDtoUpdate, UserRolDtoRemove>
    {
    }
}
