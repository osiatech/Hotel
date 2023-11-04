
using System.ComponentModel.DataAnnotations;
using System;

namespace Hotel.Application.Dtos.Recepcion
{
    public class RecepcionDtoUpdate : RecepcionDtoBase
    {
        [Key]
        public int IdRecepcion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
