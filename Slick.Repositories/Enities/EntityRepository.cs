using System;
using Slick.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Linq.Expressions;
using Slick.Models;

namespace Slick.Repositories.Enities
{
    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity, new()
    {
        private readonly ApplicationDBContext entitiesContext;

        public EntityRepository(ApplicationDBContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }

        public T Add(T obj)
        {
            EntityEntry dbEntity = entitiesContext.Add(obj);
            entitiesContext.SaveChanges();

            return obj;
        }

        public void Delete(T obj)
        {
            EntityEntry dbEntity = entitiesContext.Entry<T>(obj);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            entitiesContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return entitiesContext.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return entitiesContext.Set<T>().Where(predicate);
        }
        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = entitiesContext.Set<T>();
            {
                foreach (var includeProperty in includeProperties);
            }
            return query;
        }

        public T GetById(Guid Id)
        {
            var item = GetAll().Where(s => s.Id == Id).SingleOrDefault();
            return item;
        }

        public void Update(T obj)
        {
            EntityEntry dbEntity = entitiesContext.Entry<T>(obj);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            entitiesContext.SaveChanges();
        }

    }
}
