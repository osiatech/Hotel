using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Domain.Entities
{
    [Table("RolUsuario")]
    public class UserRol : BaseEntity
    {
        [Key]
        public int IdRolUsuario { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime RegistryDate { get; set; }

    }
}
