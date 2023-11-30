
using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Dtos.Recepcion
{
    public class RecepcionDtoUpdate : RecepcionDtoBase
    {
        [Key]
        public int IdRecepcion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaSalidaConfirmacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
