using Hotel.Application.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Response
{
    public class UserRolResponse : ServiceResult
    {
        public int UserRolId { get; set; }
    }
}
