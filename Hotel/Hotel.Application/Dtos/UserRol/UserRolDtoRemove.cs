using Hotel.Application.Dtos.Base;

namespace Hotel.Application.Dtos.UserRol
{
    public class UserRolDtoRemove : DtoBase
    {
        public int IdUserRol { get; set; }

        public bool Deleted { get; set; }
    }
}
