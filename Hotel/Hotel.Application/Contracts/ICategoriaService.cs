using Hotel.Application.Core;
using Hotel.Application.Dtos.Categoria;

namespace Hotel.Application.Contracts
{
    public interface ICategoriaService : IBaseServices <CategoriaDtoAdd, CategoriaDtoUpdate, CategoriaDtoRemove>
    {

    }
}
