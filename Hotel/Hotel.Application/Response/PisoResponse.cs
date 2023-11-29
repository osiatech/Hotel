using Hotel.Application.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Response
{
    public class PisoResponse : ServiceResult
    {
        public int IdPiso { get; set; }
    }
}
