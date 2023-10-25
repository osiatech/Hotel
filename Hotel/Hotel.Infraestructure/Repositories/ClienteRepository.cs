using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace Hotel.Infraestructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly HotelContext context;
        public ClienteRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }
        public List<Cliente> GetClienteByClienteId(int IdCliente)
        {
           var clientes = this.context.Cliente.Where(cd => cd.IdCliente == IdCliente
            ).ToList();
            return clientes;
        }
        public override List<Cliente> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Eliminado).ToList();
        }
    }
}
