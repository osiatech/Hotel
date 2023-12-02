
namespace Hotel.Web.Models.Responses.Cliente
{
    public class ClienteListResponse
    {
        public bool Success { get; set; }
        public string Messages { get; set; }
        public List<ClienteViewResult> Data { get; set; }
    }

    public class ClienteViewResult
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
