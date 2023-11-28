
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion>
    {
        public List<Recepcion> GetRecepcionByClienteId(int clienteId);
        public List<Recepcion> GetRecepcionByHabitacionId(int habitacionId);
    }
}
