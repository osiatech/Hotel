
using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IRecepcionRepository
    {
        public void Save(Recepcion recepcion);
        public void Update(Recepcion recepcion);
        public void Remove(Recepcion recepcion);
        public List<Recepcion> GetRecepciones();
        public Recepcion GetRecepcion(int id);
        public bool Exists(Expression<Func<Recepcion, bool>> filter);
    }
}
