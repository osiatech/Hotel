using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.Infraestructure.Repositories
{
    public class RecepcionRepository : IRecepcionRepository
    {
        private readonly HotelContext context;
        public RecepcionRepository(HotelContext context)
        {
            this.context = context;
        }
        public bool Exists(Expression<Func<Recepcion, bool>> filter)
        {
            return this.context.Recepciones.Any(filter);
        }

        public Recepcion GetRecepcion(int id)
        {
            return this.context.Recepciones.Find(id);
        }

        public List<Recepcion> GetRecepciones()
        {
            return this.context.Recepciones.Where(st => !st.Deleted).ToList();
        }

        public void Remove(Recepcion recepcion)
        {
            this.context.Recepciones.Remove(recepcion);
        }

        public void Save(Recepcion recepcion)
        {
            this.context.Recepciones.Add(recepcion);
        }

        public void Update(Recepcion recepcion)
        {
            this.context.Recepciones.Update(recepcion);
        }
    }
}
