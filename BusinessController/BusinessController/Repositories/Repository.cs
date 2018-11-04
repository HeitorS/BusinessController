using System.Collections.Generic;
using BusinessController.DAO;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System;

namespace BusinessController.Repositories
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        DataContext context = new DataContext();

        public TEntity Find(params object[] key)
        {
            return context.Set<TEntity>().Find(key);
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public void Add(TEntity obj)
        {
            context.Set<TEntity>().Add(obj);
        }

        public void Update(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            context.Set<TEntity>().Where(predicate).ToList().ForEach(del => context.Set<TEntity>().Remove(del));
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

}