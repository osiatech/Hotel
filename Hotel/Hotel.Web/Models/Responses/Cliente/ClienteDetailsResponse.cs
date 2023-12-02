
namespace Hotel.Web.Models.Responses.Cliente
{
    public class ClienteDetailsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ClienteViewResult Data { get; set; }
    }
}
