namespace Hotel.Web.Models.Responses
{
    public class RoomListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<RoomViewResult> data { get; set; }
    }
    public class RoomViewResult
    {
        public int idRoom { get; set; }
        public int? idRoomStatus { get; set; }
        public int idCategory { get; set; }
        public int? idFlat { get; set; }
        public string? number { get; set; }
        public string? details { get; set; }
        public decimal? price { get; set; }
        public bool? status { get; set; }
        public bool? deleted { get; set; }
        public DateTime creationDate { get; set; }

        public DateTime registryDate { get; set; }

    }
}
