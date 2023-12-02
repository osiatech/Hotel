
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

        public override List<Recepcion> GetEntities()
        {
            return base.GetEntities().Where(recepcion => !recepcion.Eliminado).ToList();
        }

        public override void Save(Recepcion entity)
        {
            base.Save(entity);
            this.context.SaveChanges();
        }

        public override void Update(Recepcion entity)
        {
            var recepcionToUpdate = base.GetEntity(entity.IdRecepcion);

            recepcionToUpdate.FechaEntrada = entity.FechaEntrada;
            recepcionToUpdate.FechaSalida = entity.FechaSalida;
            recepcionToUpdate.FechaSalidaConfirmacion = entity.FechaSalidaConfirmacion;
            recepcionToUpdate.PrecioInicial = entity.PrecioInicial;
            recepcionToUpdate.Adelanto = entity.Adelanto;
            recepcionToUpdate.PrecioRestante = entity.PrecioInicial;
            recepcionToUpdate.TotalPagado = entity.TotalPagado;
            recepcionToUpdate.CostoPenalidad = entity.CostoPenalidad;
            recepcionToUpdate.Observacion = entity.Observacion;
            recepcionToUpdate.Eliminado = entity.Eliminado;
            recepcionToUpdate.FechaMod = entity.FechaMod;
            recepcionToUpdate.IdUsuarioMod = entity.IdUsuarioMod;

            context.RECEPCION.Update(recepcionToUpdate);
            context.SaveChanges();
        }

        public override void Remove(Recepcion entity)
        {

            var recepcionToRemove = base.GetEntity(entity.IdRecepcion);

            recepcionToRemove.IdRecepcion = entity.IdRecepcion;
            recepcionToRemove.Eliminado = entity.Eliminado;
            recepcionToRemove.FechaElimino = entity.FechaElimino;
            recepcionToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;

            this.context.Update(recepcionToRemove);
            this.context.SaveChanges();
        }

        public List<Recepcion> GetRecepcionByClienteId(int IdCliente)
        {
            var recepcion = this.context.RECEPCION.Where(rc => rc.IdCliente == IdCliente).ToList();
            return recepcion;
        }

        public List<Recepcion> GetRecepcionByHabitacionId(int habitacionId)
        {
            var recepcion = this.context.RECEPCION.Where(rh => rh.IdHabitacion == habitacionId).ToList();
            return recepcion;
        }
    }
}
