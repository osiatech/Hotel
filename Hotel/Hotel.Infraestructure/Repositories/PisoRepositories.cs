using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Hotel.Infraestructure.Core;


namespace Hotel.Infraestructure.Repositories
{
    public class PisoRepositories : BaseRepository<Piso>, IPisoRepository
    {
        private readonly HotelContext context;
        public PisoRepositories(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public List<Piso> GetPisoByPisoId(int PisoId)
        {
            var pisos = this.context.Piso.Where(ps => ps.IdPiso == PisoId).ToList();
            return pisos;

        }
        public override List<Piso> GetEntities()
        {
            return base.GetEntities().Where(ps => !ps.Eliminado).ToList();
        }
    }
}