using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;

namespace Hotel.Infraestructure.Repositories
{
    public class UsuarioRepositories : IUsuarioRepository
    {
        private readonly HotelContext context;
        public UsuarioRepositories(HotelContext context)
        {
            this.context = context;
        }
        public bool Exist(Expression<Func<Usuario, bool>> filter)
        {
            return this.context.Usuarios.Any(filter);
        }

        public Usuario GetUsuario(int id)
        {
            return this.context.Usuarios.Find(id);
        }

        public List<Usuario> GetUsuarios()
        {
            return this.context.Usuarios.Where(us => !us.Deleted).ToList();
        }

        public void Remove(Usuario usuario)
        {
            this.context.Remove(usuario);
        }

        public void Save(Usuario usuario)
        {
            this.context.Usuarios.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            this.context.Update(usuario);
        }
    }


}
    