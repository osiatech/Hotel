using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Repository
{
    public interface ICategoria
    {
        public List<Categoria> GetCategorias();
        public Categoria GetCategorias(int id);
        public void Save(Categoria categoria);
        public void Update(Categoria categoria);
        public void Remove(Categoria categoria);
    }
}
