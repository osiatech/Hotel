
using System;

namespace Hotel.Application.DtoBase.Cliente
{
    public class ClienteDtoRemove : BaseDto
    {
        public int IdCliente { get; set; }
        public bool Eliminado { get; set; }
        public int IdUsuarioElimino { get; set; }
        public DateTime FechaElimino { get; set; }

    }
}
