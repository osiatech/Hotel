
using Hotel.Domain.Entities;
using System.Collections.Generic;
namespace Hotel.Domain.Repository
{
    public interface IRecepcion
    {
        public List<Recepcion> GetRecepciones();
        public Recepcion GetRecepciones(int id);
        public void Save(Recepcion recepcion);
        public void Update(Recepcion recepcion);
        public void Remove(Recepcion recepcion);
    }
}
