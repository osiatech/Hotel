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
    public class CategoriaRepositories : ICategoriaRepository
    {
        private readonly HotelContext context;
        public CategoriaRepositories (HotelContext context)
        {
            this.context = context;
        }
        public bool Exist(Expression<Func<Categoria, bool>> filter)
        {
            return this.context.Categorias.Any(filter);
        }

        public List<Categoria> GetCategorias()
        {
            return this.context.Categorias.Where(ca => !ca.Deleted).ToList();
        }

        public Categoria GetCategorias(int id)
        {
            return this.context.Categorias.Find(id);
        }

        public void Remove(Categoria categoria)
        {
            this.context.Remove(categoria);
        }

        public void Save(Categoria categoria)
        {
            this.context.Categorias.Add(categoria);
        }

        public void Update(Categoria categoria)
        {
            this.context.Update(categoria);
        }
    }
}
