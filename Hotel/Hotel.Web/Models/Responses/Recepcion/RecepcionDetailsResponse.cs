
namespace Hotel.Web.Models.Responses.Recepcion
{
    public class RecepcionDetailsResponse
    {
        public bool Success { get; set; }
        public string Messages { get; set; }
        public RecepcionViewResult Data { get; set; }
    }
}
