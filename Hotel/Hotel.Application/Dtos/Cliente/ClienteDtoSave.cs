
using System;

namespace Hotel.Application.Dtos.Cliente
{
    public class ClienteDtoSave : ClienteDtoBase
    {
        public DateTime? FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}