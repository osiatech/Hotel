
namespace Hotel.Application.Core
{
    public interface IBaseServices <TDtoAdd, TDtoUpdate, TDtoRemove>
    {
        public ServiceResult GetAll();
        public ServiceResult GetById(int id);
        public ServiceResult Save(TDtoAdd dtoAdd);
        public ServiceResult Update(TDtoAdd dtoUpdate);
        public ServiceResult Remove(TDtoRemove dtoRemove);
    }
}
