
namespace Hotel.Web.Models.Responses
{
    public class ClienteListResponse
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public List<ClienteViewResponse> Data { get; set; }
    }

    public class ClienteViewResponse
    {
        public int IdCliente { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
