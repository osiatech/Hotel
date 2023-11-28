using Hotel.Application.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.Response
{
    public class CategoriaResponse : ServiceResult
    {
        public int CategoriaId { get; set; }

    }
}
