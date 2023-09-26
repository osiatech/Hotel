
using System.Collections.Generic;
using Hotel.Domain.Entities;
namespace Hotel.Domain.Repository
{
    public interface ICliente
    {
        public List<Cliente> GetClientes();
        public Cliente GetClientes(int id);
        public void Save(Cliente cliente);
        public void Update(Cliente cliente);
        public void Remove(Cliente cliente);
    }
}
