using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Domain.Core
{
    public abstract class BaseEntity
    {
        [Column("FechaCreacion")]
        public DateTime? CreationDate { get; set; }
        [Column("IdUsuarioCreacion")]
        public int CreationUser { get; set; }
        [Column("FechaMod")]
        public DateTime? ModifyDate { get; set; }
        [Column("IdUsuarioMod")]
        public int? UserModify { get; set; }
        [Column("IdUsuarioElimino")]
        public int? UserDeleted { get; set; }
        [Column("FechaElimino")]
        public DateTime? DeletedDate { get; set; }
        [Column("Eliminado")]
        public bool Deleted { get; set; }
    }
}
