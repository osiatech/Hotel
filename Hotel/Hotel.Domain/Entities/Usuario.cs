﻿using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        [Key]
            public int IdUsuario { get; set; }
            public string? NombreCompleto { get; set; }
            public string? Correo { get; set; }
            public int? IdRolUsuario { get; set; }
            public string? Clave { get; set; }
            public bool? Estado { get; set; } 
            
    }

    
}
