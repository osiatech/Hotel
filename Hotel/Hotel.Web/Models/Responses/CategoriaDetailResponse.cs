namespace Hotel.Web.Models.Responses
{
    public class CategoriaDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public CategoriaViewResult data { get; set; }
    }
}
