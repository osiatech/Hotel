
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infraestructure.Models.Recepcion;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion>
    {
        public List<RecepcionClienteModel> GetRecepcionByClienteId(int IdCliente);
        public List<RecepcionHabitacionModel> GetRecepcionByHabitacionId(int IdHabitacionId);

        public List<RecepcionHabitacionModel> GetRecepcionesHabitaciones();

        public RecepcionHabitacionModel GetRecepcionHabitacion(int id);
    }
}
