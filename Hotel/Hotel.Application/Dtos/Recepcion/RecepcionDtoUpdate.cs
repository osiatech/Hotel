
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Dtos.Recepcion
{
    public class RecepcionDtoUpdate : RecepcionDtoBase
    {
        [Key]
        public int IdRecepcion { get; set; }
    }
}
