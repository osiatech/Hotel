
namespace Hotel.Application.Core
{
    public interface IBaseServices <TDtoSave, TDtoUpdate, TDtoRemove>
    {
        public ServiceResult Save(TDtoSave dtoSave);
        public ServiceResult Update(TDtoUpdate dtoUpdate);
        public ServiceResult Remove(TDtoRemove dtoRemove);
        public ServiceResult GetAll();
        public ServiceResult GetById(int id);
    }
}
