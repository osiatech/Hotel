using Hotel.Application.Core;
using Hotel.Application.Dtos.Piso;


namespace Hotel.Application.Contracts
{
    public interface IPisoService : IBaseServices<PisoDtoAdd, PisoDtoUpdate, PisoDtoRemove>
    {
    }
}
