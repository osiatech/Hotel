using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        public List<Cliente> GetClienteByClienteId(int IdCliente);
    } 
}
