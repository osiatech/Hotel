﻿using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IPisoRepository : IBaseRepository<Piso>
    {
        public List<Piso> GetPisoByPisoId(int IdPiso);
    }
}
