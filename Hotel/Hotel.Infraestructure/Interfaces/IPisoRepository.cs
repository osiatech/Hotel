using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IPisoRepository
    {
        public List<Piso> GetPisos();
        public Piso GetPiso(int id);
        public void Save(Piso piso);
        public void Update(Piso piso);
        public void Remove(Piso piso);
        public bool Exist(Expression<Func<Piso, bool>> filter);
    }
}
