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
    public class PisoRepositories : IPisoRepository

    {
        private readonly HotelContext context;
        public PisoRepositories(HotelContext context) 
        {  this.context = context;
        }
        public bool Exist(Expression<Func<Piso, bool>> filter)
        {
            return this.context.Pisos.Any(filter);
        }

        public Piso GetPiso(int id)
        {
            return this.context.Pisos.Find(id);
        }

        public List<Piso> GetPisos()
        {
            return this.context.Pisos.Where(ca => !ca.Deleted).ToList();
        }

        public void Remove(Piso piso)
        {
            this.context.Remove(piso);
        }

        public void Save(Piso piso)
        {
            this.context.Pisos.Add(piso);
        }

        public void Update(Piso piso)
        {
            this.context.Update(piso);
        }
    }
}
