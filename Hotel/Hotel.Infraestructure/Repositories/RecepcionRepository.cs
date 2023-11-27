using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Models.Recepcion;
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
            Recepcion recepcion = this.GetEntity(entity.IdRecepcion);

            recepcion.IdCliente = entity.IdCliente;
            recepcion.IdHabitacion = entity.IdHabitacion;

            recepcion.PrecioInicial = entity.PrecioInicial;
            recepcion.Adelanto = entity.Adelanto;
            recepcion.PrecioRestante = entity.PrecioRestante;
            recepcion.TotalPagado = entity.TotalPagado;
            recepcion.CostoPenalidad = entity.CostoPenalidad;
            recepcion.Observacion = entity.Observacion;

            this.context.RECEPCION.Update(recepcion);
            this.context.SaveChanges();
        }

        public override void Remove(Recepcion entity)
        {

            var recepcion = this.GetEntity(entity.IdRecepcion);

            recepcion.IdRecepcion = entity.IdRecepcion;
            recepcion.Eliminado = entity.Eliminado;
            recepcion.FechaElimino = entity.FechaElimino;
            recepcion.IdUsuarioElimino = entity.IdUsuarioElimino;

            this.context.RECEPCION.Update(recepcion);
            this.context.SaveChanges();
        }

        public List<RecepcionClienteModel> GetRecepcionByClienteId(int IdCliente)
        {
            throw new System.NotImplementedException();
        }

        public List<RecepcionHabitacionModel> GetRecepcionByHabitacionId(int habitacionId)
        {
            return this.GetRecepcionesHabitaciones().Where(rh => rh.IdHabitacion == habitacionId).ToList();
        }

        public List<RecepcionHabitacionModel> GetRecepcionesHabitaciones()
        {
            var recepciones = (from recepcion in this.GetEntities()
                               join habitacion in this.context.Habitacion
                               on recepcion.IdHabitacion equals habitacion.IdHabitacion
                               where !recepcion.Eliminado
                               select new RecepcionHabitacionModel()
                               {
                                   IdRecepcion = recepcion.IdRecepcion,
                                   IdHabitacion = recepcion.IdHabitacion,
                                   IdCliente = recepcion.IdCliente,
                                   PrecioInicial = recepcion.PrecioInicial,
                                   Adelanto = recepcion.Adelanto,
                                   PrecioRestante = recepcion.PrecioRestante,
                                   TotalPagado = recepcion.TotalPagado,
                                   CostoPenalidad = recepcion.CostoPenalidad,
                                   Observacion = recepcion.Observacion,
                                   Eliminado = recepcion.Eliminado
                               }).ToList();
            return recepciones;
        }

        public RecepcionHabitacionModel GetRecepcionHabitacion(int id)
        {
            return this.GetRecepcionesHabitaciones().SingleOrDefault(recepcion => recepcion.IdRecepcion == id);
        }

        public List<Recepcion> GetRecepcionesByHabitacion(int habitacionId)
        {
            return this.context.RECEPCION.Where(recepcion => recepcion.IdRecepcion ==
            habitacionId && !recepcion.Eliminado).ToList(); 
        }
    }
}
