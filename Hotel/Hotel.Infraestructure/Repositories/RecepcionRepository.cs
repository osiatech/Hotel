using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Infraestructure.Repositories
{
    public class RecepcionRepository : BaseRepository<Recepcion>, IRecepcionRepository
    {

        private readonly HotelContext context;

        public RecepcionRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public List<Recepcion> GetRecepcionByClienteId(int clienteId)
        {
            var recepcion = this.context.RECEPCION.Where(recepcion => recepcion.IdCliente == clienteId).ToList();
            return recepcion;
        }

        public List<Recepcion> GetRecepcionByHabitacionId(int habitacionId)
        {
            var recepcion = this.context.RECEPCION.Where(recepcion =>recepcion.IdHabitacion == habitacionId).ToList();
            return recepcion;
        }

        public override List<Recepcion> GetEntities()
        {
            return this.context.RECEPCION.Where(recepcion => !recepcion.Eliminado).OrderByDescending(
                recepcion => recepcion.FechaCreacion).ToList();
        }

        public override void Save(Recepcion entity)
        {
            context.RECEPCION.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Recepcion entity)
        {

            var recepcionToUpdate = base.GetEntity(entity.IdRecepcion);

            recepcionToUpdate.IdCliente = entity.IdCliente;
            recepcionToUpdate.IdHabitacion = entity.IdHabitacion;

            recepcionToUpdate.PrecioInicial = entity.PrecioInicial;
            recepcionToUpdate.Adelanto = entity.Adelanto;
            recepcionToUpdate.PrecioRestante = entity.PrecioRestante;
            recepcionToUpdate.TotalPagado = entity.TotalPagado;
            recepcionToUpdate.CostoPenalidad = entity.CostoPenalidad;
            recepcionToUpdate.Observacion = entity.Observacion;
            recepcionToUpdate.Estado = entity.Estado;

            recepcionToUpdate.FechaRegistro = entity.FechaRegistro;
            recepcionToUpdate.FechaMod = entity.FechaMod;
            recepcionToUpdate.IdUsuarioMod = entity.IdUsuarioMod;

            context.RECEPCION.Update(recepcionToUpdate);
            context.SaveChanges();
        }

        public override void Remove(Recepcion entity)
        {

            var recepcionToRemove = base.GetEntity(entity.IdRecepcion);

            recepcionToRemove.IdRecepcion = entity.IdRecepcion;

            recepcionToRemove.PrecioInicial = entity.PrecioInicial;
            recepcionToRemove.Adelanto = entity.Adelanto;
            recepcionToRemove.PrecioRestante = entity.PrecioRestante;
            recepcionToRemove.TotalPagado = entity.TotalPagado;
            recepcionToRemove.CostoPenalidad = entity.CostoPenalidad;
            recepcionToRemove.Observacion = entity.Observacion;
            recepcionToRemove.Estado = entity.Estado;

            recepcionToRemove.FechaRegistro = entity.FechaRegistro;
            recepcionToRemove.FechaMod = entity.FechaMod;
            recepcionToRemove.IdUsuarioMod = entity.IdUsuarioMod;

            this.context.Update(recepcionToRemove);
            this.context.SaveChanges();
        }
    }
}
