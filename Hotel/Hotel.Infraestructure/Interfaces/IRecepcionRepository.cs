
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infraestructure.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion>
    {
        public List<Recepcion> GetRecepcionByClienteId(int IdCliente);
        public List<Recepcion> GetRecepcionByHabitacionId(int IdHabitacion);
    }
}
