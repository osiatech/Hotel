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
        public override void Save(Piso entity)
        {
            context.Piso.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Piso entity)
        {
            var pisoToUpdate = base.GetEntity(entity.IdPiso);

            pisoToUpdate.FechaRegistro = entity.FechaRegistro;
            pisoToUpdate.Descripcion = entity.Descripcion;
            pisoToUpdate.Estado = entity.Estado;
            pisoToUpdate.FechaMod = entity.FechaMod;
            pisoToUpdate.IdUsuarioMod = entity.IdUsuarioMod;

            context.Piso.Update(pisoToUpdate);
            context.SaveChanges();

        }

        public override void Remove(Piso entity)
        {

            var pisoToRemove = base.GetEntity(entity.IdPiso);

            pisoToRemove.IdPiso = entity.IdPiso;
            pisoToRemove.Eliminado = entity.Eliminado;
            pisoToRemove.FechaElimino = entity.FechaElimino;
            pisoToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;

            this.context.Update(pisoToRemove);
            this.context.SaveChanges();
        }


        public override List<Piso> GetEntities()
        {
            return this.context.Piso.Where(ps => !ps.Eliminado).OrderByDescending(ps => ps.FechaCreacion).ToList(); 
            
        }
    }
}