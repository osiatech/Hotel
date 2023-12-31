﻿
using System;

namespace Hotel.Application.Dtos.Recepcion
{
    public class RecepcionDtoSave : RecepcionDtoBase
    {
        public int? IdCliente { get; set; } 
        public int? IdHabitacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaSalidaConfirmacion { get; set; }
    }
}
