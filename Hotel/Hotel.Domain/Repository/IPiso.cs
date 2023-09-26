using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Repository
{
    public interface IPiso
    {
        public List<Piso> GetPisos();
        public Piso GetPisos(int id);
        public void Save(Piso piso);
        public void Update (Piso piso);
        public void Remove(Piso piso);
    }
}
