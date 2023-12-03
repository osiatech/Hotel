
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hotel.Domain.Repository
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        public void Save(TEntity entity);
        public void Update (TEntity entity);
        public void Remove (TEntity entity);
        public List<TEntity> GetEntities();
        public TEntity GetEntity(int id);
        public List <TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        public bool Exist(Expression<Func<TEntity, bool>> filter);
    }
}