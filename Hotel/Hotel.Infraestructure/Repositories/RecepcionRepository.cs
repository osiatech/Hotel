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
            var recepciones = this.context.RECEPCION.Where(cd => cd.IdCliente == clienteId).ToList();
            return recepciones;
        }

        public List<Recepcion> GetRecepcionByHabitacionId(int habitacionId)
        {
            var recepciones = this.context.RECEPCION.Where(cd => cd.IdHabitacion == habitacionId).ToList();
            return recepciones;
        }

        public override List<Recepcion> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Eliminado).ToList();
        }
    }
}
