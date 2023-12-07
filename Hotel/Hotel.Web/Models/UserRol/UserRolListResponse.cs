namespace Hotel.Web.Models.UserRol
{
    public class UserRolListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<UserRolViewResult> data { get; set; }
    }

    public class UserRolViewResult
    {
        public int idUserRol { get; set; }

        public string? description { get; set; }
        public bool? status { get; set; }
        public bool? deleted { get; set; }
        public int changeUser { get; set; }
        public DateTime creationDate { get; set; }
        public int IdCreationUser { get; set; }
        public DateTime changeDate { get; set; }
        public DateTime registryDate { get; set; }

    }
}
