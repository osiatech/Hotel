using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Repository
{
    public interface ICategoriaRepository
    {
        public List<Categoria> GetCategorias();
        public Categoria GetCategorias(int id);
        public void Save(Categoria categoria);
        public void Update(Categoria categoria);
        public void Remove(Categoria categoria);
    }
}
