namespace Hotel.API.Models.Core
{
    public class UserRolBaseModel : ModelBase
    {
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime RegistryDate { get; set; }
    }
}
