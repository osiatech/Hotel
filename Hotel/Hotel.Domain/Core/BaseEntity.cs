using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Domain.Core
{
    public abstract class BaseEntity
    {
        [Column("FechaCreacion")]
        public DateTime CreationDate { get; set; }
        [Column("IdUsuarioCreacion")]
        public int IdCreationUser { get; set; }
        [Column("FechaMod")]
        public DateTime? ModifyDate { get; set; }
        [Column("IdUsuarioMod")]
        public int? IdUserModify { get; set; }
        [Column("IdUsuarioElimino")]
        public int? IdUserDeleted { get; set; }
        [Column("FechaElimino")]
        public DateTime? DeletedDate { get; set; }
        [Column("Eliminado")]
        public bool Deleted { get; set; }
    }
}
