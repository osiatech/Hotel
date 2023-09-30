using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.Infraestructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly HotelContext context;
        public ClienteRepository(HotelContext context)
        {
            this.context = context;
        }
        public bool Exists(Expression<Func<Cliente, bool>> filter)
        {
            return this.context.Clientes.Any(filter);
        }

        public Cliente GetCliente(int id)
        {
            return this.context.Clientes.Find(id);
        }

        public List<Cliente> GetClientes()
        {
            return this.context.Clientes.Where(st => !st.Deleted).ToList();
        }

        public void Remove(Cliente cliente)
        {
            this.context.Clientes.Remove(cliente);
        }

        public void Save(Cliente cliente)
        {
            this.context.Clientes.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            this.context.Clientes.Update(cliente);
        }
    }
}
