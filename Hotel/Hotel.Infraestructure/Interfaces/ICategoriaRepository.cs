using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.Infraestructure.Interfaces
{
    public interface ICategoriaRepository
    {
        public List<Categoria> GetCategorias();
        public Categoria GetCategorias(int id);
        public void Save(Categoria categoria);
        public void Update(Categoria categoria);
        public void Remove(Categoria categoria);
        public bool Exist (Expression <Func <Categoria, bool >> filter);
    }
}
