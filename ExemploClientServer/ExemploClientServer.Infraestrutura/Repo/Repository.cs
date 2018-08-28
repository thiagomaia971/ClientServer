using System;
using System.Linq;
using ExemploClientServer.Core.Interfaces.Repo;
using ExemploClientServer.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExemploClientServer.Infraestrutura.Repo
{
    public class Repository<T> : IRepository<T> where T: Entity
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            this.Context = context;
            _dbSet = Context.Set<T>();
        }

        public virtual void Add(T entity)
            => _dbSet.Add(entity);

        public virtual void Delete(int id)
            => Delete(GetSingle(id));

        public virtual void Delete(T entity)
            => _dbSet.Remove(entity);

        public virtual IQueryable<T> GetAll()
            => Filter();

        public virtual IQueryable<T> GetAll(Func<T, bool> predicate)
            => Filter().AsEnumerable().Where(predicate).AsQueryable();

        public virtual T GetSingle(int id)
            => Filter().SingleOrDefault(x => x.Id == id);

        public virtual void Update(T entity)
            => _dbSet.Update(entity);

        public virtual IQueryable<T> Filter()
            => _dbSet;

        public virtual void SaveChanges() 
            => Context.SaveChanges();
    }
}