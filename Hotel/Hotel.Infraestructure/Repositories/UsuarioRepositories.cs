using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Hotel.Infraestructure.Core;

namespace Hotel.Infraestructure.Repositories
{
    public class UsuarioRepositories : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly HotelContext context;
        public UsuarioRepositories(HotelContext context) : base(context)
        {
            this.context = context;
        }


        public override List<Usuario> GetEntities()
        {
            return base.GetEntities().Where(us => !us.Eliminado).ToList();
        }
    }
}