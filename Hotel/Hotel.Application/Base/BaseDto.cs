
using System;

namespace Hotel.Application.DtoBase
{
    public abstract class BaseDto
    {
        public int? ChangeUser { get; set; }
        public DateTime? ChangeDate { get; set; }
    }
}