

using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Dtos.Room
{
    public class RoomDtoUpdate : RoomDtoBase
    {
        [Key]
        public int IdRoom { get; set; }
    }
}
