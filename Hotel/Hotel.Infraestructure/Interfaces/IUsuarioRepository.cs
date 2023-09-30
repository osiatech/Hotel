using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IUsuarioRepository
    {
        public List<Usuario> GetUsuarios();
        public Usuario GetUsuario(int id);
        public void Save(Usuario usuario);
        public void Update(Usuario usuario);
        public void Remove(Usuario usuario);
        public bool Exist(Expression<Func<Usuario, bool>> filter);
    }
}
