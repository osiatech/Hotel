using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IClienteRepository
    {
        public void Save(Cliente cliente);
        public void Update(Cliente cliente);
        public void Remove(Cliente cliente);
        public List<Cliente> GetClientes();
        public Cliente GetCliente(int id);
        public bool Exists(Expression <Func<Cliente, bool>> filter);
    }

    
}
