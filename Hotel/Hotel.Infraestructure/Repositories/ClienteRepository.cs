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
           var cliente = this.context.Cliente.Where(cliente => cliente.IdCliente == IdCliente
            ).ToList();
            return cliente;
        }

        public override List<Cliente> GetEntities()
        {
            return this.context.Cliente.Where(cliente => !cliente.Eliminado).OrderByDescending(
                cliente => cliente.FechaCreacion).ToList();
        }

        public override void Save(Cliente entity)
        {
            context.Cliente.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Cliente entity)
        {

            var clienteToUpdate = base.GetEntity(entity.IdCliente);

            clienteToUpdate.NombreCompleto = entity.NombreCompleto;
            clienteToUpdate.Documento = entity.Documento;
            clienteToUpdate.TipoDocumento = entity.TipoDocumento;
            clienteToUpdate.Correo = entity.Correo;
            clienteToUpdate.FechaMod = entity.FechaMod;
            clienteToUpdate.IdUsuarioMod = entity.IdUsuarioMod;

            context.Cliente.Update(clienteToUpdate);
            context.SaveChanges();
        }

        public override void Remove(Cliente entity)
        {

            var clienteToRemove = base.GetEntity(entity.IdCliente);
            
            clienteToRemove.IdCliente = entity.IdCliente;
            clienteToRemove.Eliminado = entity.Eliminado;
            clienteToRemove.FechaElimino = entity.FechaElimino;
            clienteToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;

            this.context.Update(clienteToRemove);
            this.context.SaveChanges();
        }
    }
}
