using Hotel.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.Domain.Entities
{
    [Table("RolUsuario")]
    public class UserRol : BaseEntity
    {
        [Key]
        [Column("IdRolUsuario")]
        public int IdUserRol { get; set; }
        [Column("Descripcion")]
        public string? Description { get; set; }
        [Column("Estado")]
        public bool? Status { get; set; }
        [Column("FechaRegistro")]
        public DateTime RegistryDate { get; set; }

    }
}
