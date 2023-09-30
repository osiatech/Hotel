using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infraestructure.Interfaces
{
    public interface ICategoriaRepository
    {
        public List<Categoría> GetCategorias();
        public Categoría GetCategorias(int id);
        public void Save(Categoría categoria);
        public void Update(Categoría categoría);
        public void Remove(Categoría categoría);
    }
}
