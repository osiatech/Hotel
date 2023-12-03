
namespace Hotel.API.Modules.Cliente
{
    public class GetClienteModel
    {
        public int IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo {  get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}