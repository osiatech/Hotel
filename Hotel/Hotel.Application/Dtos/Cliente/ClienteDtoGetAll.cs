
using Hotel.Application.DtoBase;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Dtos.Cliente
{
    public class ClienteDtoGetAll : BaseDto
    {
        [Key]
        public int IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo {  get; set; }
        public string? Documento { get; set; }
        public bool Eliminado { get; set; }
    }
}
