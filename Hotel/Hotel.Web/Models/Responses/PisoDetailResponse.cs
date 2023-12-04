namespace Hotel.Web.Models.Responses
{
    public class PisoDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public PisoViewResult data { get; set; }
    }
}
