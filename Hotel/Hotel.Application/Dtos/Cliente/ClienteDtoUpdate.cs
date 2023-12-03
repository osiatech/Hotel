
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Dtos.Cliente
{
    public class ClienteDtoUpdate : ClienteDtoBase
    {
        [Key]
        public int IdCliente { get; set; }
    }    
 }