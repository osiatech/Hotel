using Hotel.Application.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Response
{
    public class RoomResponse : ServiceResult
    {
        public int RoomId { get; set; }
    }
}
