using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        public List<Cliente> GetClienteByClienteId(int IdCliente);
    } 
}
