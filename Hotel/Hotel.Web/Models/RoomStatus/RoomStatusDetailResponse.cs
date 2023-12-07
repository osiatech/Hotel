namespace Hotel.Web.Models.RoomStatus
{
    public class RoomStatusDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public RoomStatusViewResult data { get; set; }
    }
}
