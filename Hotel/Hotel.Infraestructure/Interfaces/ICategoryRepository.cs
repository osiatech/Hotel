using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infraestructure.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
