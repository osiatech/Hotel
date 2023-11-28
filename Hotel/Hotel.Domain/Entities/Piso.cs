using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class Piso : BaseEntity
    {

        public int IdPiso { get; set; }
        public String? Descripcion { get; set; }
        public Boolean? Estado { get; set; }


    }
}
