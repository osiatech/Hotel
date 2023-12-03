
using Hotel.Application.Core;
using Hotel.Application.DtoBase.Cliente;
using Hotel.Application.Dtos.Cliente;

namespace Hotel.Application.Contracts
{
    public interface IClienteService : IBaseServices <ClienteDtoSave,ClienteDtoUpdate, ClienteDtoRemove> {}
}