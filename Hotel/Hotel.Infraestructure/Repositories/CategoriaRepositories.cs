using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Hotel.Infraestructure.Core;
using Hotel.Domain.Repository;

namespace Hotel.Infraestructure.Repositories
{
    public class CategoriaRepositories : BaseRepository <Categoria>,ICategoriaRepository
    {
        private readonly HotelContext context;
        public CategoriaRepositories (HotelContext context) : base (context)
        {
            this.context = context;
        }

        public override void Save(Categoria entity)
        {
            context.Categoria.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Categoria entity)
        {
            var categoriaToUpdate = base.GetEntity(entity.IdCategoria);

            categoriaToUpdate.FechaRegistro = entity.FechaRegistro;
            categoriaToUpdate.Descripcion = entity.Descripcion;
            categoriaToUpdate.Estado = entity.Estado;
            categoriaToUpdate.FechaMod = entity.FechaMod;
            categoriaToUpdate.IdUsuarioMod = entity.IdUsuarioMod;

            context.Categoria.Update(categoriaToUpdate);
            context.SaveChanges();

        }
        public override void Remove(Categoria entity)
        {

            var categoriaToRemove = base.GetEntity(entity.IdCategoria);

            categoriaToRemove.IdCategoria = entity.IdCategoria;
            categoriaToRemove.Eliminado = entity.Eliminado;
            categoriaToRemove.FechaElimino = entity.FechaElimino;
            categoriaToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;

            this.context.Update(categoriaToRemove);
            this.context.SaveChanges();
        }
        public override List<Categoria> GetEntities()
        {
            return this.context.Categoria.Where(ct => !ct.Eliminado).OrderByDescending(ct => ct.FechaCreacion).ToList();
        }
    }    
}

