using System.Collections.Generic;

namespace Hotel.Domain.Repository
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        public void Save(TEntity entity);
        public void Update(TEntity entity);
        public void Remove(TEntity entity);
        public List<TEntity> GetEntities();
        public TEntity GetEntity(int id);
    }
}
