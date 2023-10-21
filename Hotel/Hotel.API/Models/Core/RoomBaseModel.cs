namespace Hotel.API.Models.Core
{
    public class RoomBaseModel : ModelBase
    {
        public string? Number { get; set; }
        public string? Details { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public DateTime RegistryDate { get; set; }
    }
}
