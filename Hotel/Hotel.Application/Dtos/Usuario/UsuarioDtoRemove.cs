

namespace Hotel.Application.Dtos.Usuario
{
    public class UsuarioDtoRemove : DtoBase
    {
        public bool Eliminado { get; set; }
        public int Id { get; internal set; }
    }
}
