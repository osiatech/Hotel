using Hotel.Application.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Response
{
    public class RoomStatusResponse : ServiceResult
    {
        public int RoomStatusId { get; set; }
    }
}
