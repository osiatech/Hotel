
using Hotel.Application.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Response
{
    public class ClienteResponse : ServiceResult
    {
        [Key]
        public int IdCliente { get; set; }
    }
}
