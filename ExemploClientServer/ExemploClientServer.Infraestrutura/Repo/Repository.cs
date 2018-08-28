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

        public void Add(T entity)
            => _dbSet.Add(entity);

        public void Delete(int id)
            => Delete(GetSingle(id));

        public void Delete(T entity)
            => _dbSet.Remove(entity);

        public IQueryable<T> GetAll()
            => Filter();

        public IQueryable<T> GetAll(Func<T, bool> predicate)
            => Filter().AsEnumerable().Where(predicate).AsQueryable();

        public T GetSingle(int id)
            => Filter().SingleOrDefault(x => x.Id == id);

        public void Update(T entity)
            => _dbSet.Update(entity);

        public virtual IQueryable<T> Filter()
            => _dbSet;
    }
}