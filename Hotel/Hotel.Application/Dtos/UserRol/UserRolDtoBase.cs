using Hotel.Application.Dtos.Base;
using System;

namespace Hotel.Application.Dtos.UserRol
{
    public class UserRolDtoBase : DtoBase
    {
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime RegistryDate { get; set; }
    }
}
