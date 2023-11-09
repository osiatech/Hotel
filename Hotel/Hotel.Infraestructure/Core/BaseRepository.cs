using Hotel.Domain.Repository;
using Hotel.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Hotel.Domain.Entities;

namespace Hotel.Infraestructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly HotelContext context;
        private DbSet<TEntity> entities;

        public BaseRepository(HotelContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }
        public virtual bool Exist(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return this.entities.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
            this.SaveChange();
        }

        public virtual void Save(TEntity entity)
        {
            this.entities.Add(entity);
            this.SaveChange();
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
            this.SaveChange();
        }

        public virtual void SaveChange()
        {
            context.SaveChanges();
        }
    }
}