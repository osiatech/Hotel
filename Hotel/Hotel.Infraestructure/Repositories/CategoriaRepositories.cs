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
        public CategoriaRepositories(HotelContext context)
        {
            this.context = context;
        }
        public bool Exist(Expression<Func<Categoria, bool>> filter)
        {
            return this.context.Categorias.Any(filter);
        }

        public List<Categoria> GetCategorias()
        {
            throw new NotImplementedException();
        }

        public Categoria GetCategorias(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Categoria categoría)
        {
            throw new NotImplementedException();
        }

        public void Save(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria categoría)
        {
            throw new NotImplementedException();
        }
    }
}
