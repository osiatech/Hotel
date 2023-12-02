
namespace Hotel.Web.Models.Responses.Base
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
