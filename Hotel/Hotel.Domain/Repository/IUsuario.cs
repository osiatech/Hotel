using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Repository
{
    public interface IUsuario
    {
        public List<Usuario> GetUsuarios();
        public Usuario GetUsuarios(int id);
        public void Save(Usuario usuario);
        public void Update(Usuario usuario);
        public void Remove(Usuario usuario);
    }
}
