using Hotel.Application.Core;
using Hotel.Application.Dtos.Usuario;


namespace Hotel.Application.Contracts
{
    public interface IUsuarioService : IBaseServices<UsuarioDtoAdd, UsuarioDtoUpdate, UsuarioDtoRemove>
    {
    }
}
