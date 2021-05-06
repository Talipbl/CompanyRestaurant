using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        //Base Database Operations

        private int TContextEntry(TEntity entity, EntityState state)
        {
            using (TContext db = new TContext())
            {
                db.Entry<TEntity>(entity).State = state;
                return db.SaveChanges();
            }
        }
        public bool Add(TEntity entity)
        {
            return TContextEntry(entity, EntityState.Added) > 0 ? true : false;
        }

        public bool Delete(TEntity entity)
        {
            return TContextEntry(entity, EntityState.Deleted) > 0 ? true : false;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext db = new TContext())
            {
                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext db = new TContext())
            {
                return filter == null ? db.Set<TEntity>().ToList() : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public bool Update(TEntity entity)
        {
            return TContextEntry(entity, EntityState.Modified) > 0 ? true : false;
        }
    }
}
