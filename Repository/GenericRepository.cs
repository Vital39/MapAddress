using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private DbContext context;
        private IDbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void AddOrUpdate(T obj)
        {
            try
            {
                dbSet.AddOrUpdate(obj);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Delete(T obj)
        {
            try
            {
                dbSet.Remove(obj);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public int Save()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
