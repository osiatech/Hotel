
using Hotel.Application.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Response
{
    public class RecepcionResponse : ServiceResult
    {
        [Key]
        public int IdRecepcion { get; set; }
    }
}