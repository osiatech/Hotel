using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hotel.Infraestructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly HotelContext context;
        public ClienteRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }
        public List<Cliente> GetClienteByClienteId(int clienteId)
        {
           var clientes = this.context.Cliente.Where(cd => cd.IdCliente == clienteId
            ).ToList();
            return clientes;
        }
        public override List<Cliente> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Eliminado).ToList();
        }
    }
}
