using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.Infraestructure.Repositories
{
    public class PisoRepositories : IPisoRepository

    {
        private readonly HotelContext context;
        public PisoRepositories (HotelContext context)
        {
            this.context = context;
        }
        public bool Exist(Expression<Func<Piso, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Piso> GetPiso()
        {
            throw new NotImplementedException();
        }

        public Piso GetPiso(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Piso piso)
        {
            throw new NotImplementedException();
        }

        public void Save(Piso piso)
        {
            throw new NotImplementedException();
        }

        public void Update(Piso piso)
        {
            throw new NotImplementedException();
        }
    }
}
