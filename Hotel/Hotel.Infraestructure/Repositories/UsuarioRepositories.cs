using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.Infraestructure.Repositories
{
    public class UsuarioRepositories : IUsuarioRepository
    {
        private readonly HotelContext context;
        public UsuarioRepositories (HotelContext context)
        {
            this.context = context;
        }
        public bool Exist(Expression<Func<Usuario, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuario()
        {
            throw new NotImplementedException();
        }

        public Piso GetUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Piso usuario)
        {
            throw new NotImplementedException();
        }

        public void Save(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Update(Piso usuario)
        {
            throw new NotImplementedException();
        }
    }
}
