using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ToDo.Data.Context;

namespace ToDo.Data
{
    public interface IRepository<T> where T: class
    {
        T Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IQueryable<T> Query();
        void Add(T entity);
        void Remove(T entity);
        void Save();
        bool CheckExists(int id);
        int Count();
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IToDoContextProvider _ctx;
        public Repository(IToDoContextProvider ctx)
        {
            _ctx = ctx;
        } 

        public T Get(int id)
        {
            return _ctx.DataContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _ctx.DataContext.Set<T>();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _ctx.DataContext.Set<T>().Where(predicate);
        }

        public void Add(T entity)
        {
            _ctx.DataContext.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {

            _ctx.DataContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return _ctx.DataContext.Set<T>().AsQueryable();
        }

        public void Save()
        {
            _ctx.DataContext.SaveChanges();
        }

        public bool CheckExists(int id)
        {
            var entity = _ctx.DataContext.Set<T>().Find(id);
            return entity != null;
        }

        public int Count()
        {
            return _ctx.DataContext.Set<T>().Count();
        }
    }
}
