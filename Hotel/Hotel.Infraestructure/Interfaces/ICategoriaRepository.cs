using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.Infraestructure.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        public List<Categoria> Get(int IdCategoria);
    }
}
