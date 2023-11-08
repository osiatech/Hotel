
using System;
using System.Data;

namespace Hotel.Application.Dtos
{
    public abstract class DtoBase
    {
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }

    }
}
