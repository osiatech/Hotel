namespace Hotel.Web.Models.Responses
{
    public class RoomDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public RoomViewResult data { get; set; }
    }
}
