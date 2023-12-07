namespace Hotel.Web.Models.RoomStatus
{
    public class RoomStatusListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<RoomStatusViewResult> data { get; set; }
    }

    public class RoomStatusViewResult
    {
        public int? idRoomStatus { get; set; }
        public int? changeUser { get; set; }
        public int? idCreationUser { get; set; }
        public DateTime changeDate { get; set; }
        public bool? deleted { get; set; }
        public string? description { get; set; }
        public int? idUserModify { get; set; }
        public bool? status { get; set; }
        public DateTime registryDate { get; set; }
    }
}
