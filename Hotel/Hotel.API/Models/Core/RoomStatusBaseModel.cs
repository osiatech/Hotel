namespace Hotel.API.Models.Core
{
    public class RoomStatusBaseModel : ModelBase
    {
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime RegistryDate { get; set; }
    }
}
