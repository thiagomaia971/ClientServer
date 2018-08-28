using System;
using System.Linq;
using ExemploClientServer.Core.Entities;

namespace ExemploClientServer.Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Func<T, bool> predicate);
        T GetSingle(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        IQueryable<T> Filter();
    }
}