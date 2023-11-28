using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Hotel.Infraestructure.Core;

namespace Hotel.Infraestructure.Repositories
{
    public class CategoriaRepositories : BaseRepository <Categoria>,ICategoriaRepository
    {
        private readonly HotelContext context;
        public CategoriaRepositories (HotelContext context) : base (context)
        {
            this.context = context;
        }
      
       
        public override List<Categoria> GetEntities()
        {
            return base.GetEntities().Where(ct => !ct.Eliminado).ToList();
        }
    }    
}

