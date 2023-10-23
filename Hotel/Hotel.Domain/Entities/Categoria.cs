using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        [Key]
        public int IdCategoria { get; set; }
        public String? Descripcion { get; set; }
        public Boolean? Estado { get; set; }
        
       
    }
}
