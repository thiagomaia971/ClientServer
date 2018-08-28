using System;
using System.Linq;
using ExemploClientServer.Core.Interfaces.Repo;
using ExemploClientServer.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExemploClientServer.Infraestrutura.Repo
{
    public class ComputerRepository : Repository<Computer>, IComputerRepository
    {
        public ComputerRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<Computer> GetAll()
        {
            return Context.Set<Computer>()
                    .Include(x => x.Process);
        }

        public override IQueryable<Computer> GetAll(Func<Computer, bool> predicate) 
            => Context.Set<Computer>().Include(x => x.Process).Where(predicate).AsQueryable();

        public Computer GetByNameAndIp(string nomeMaquina, string ip) 
            => Context.Set<Computer>().Where(x => x.Nome == nomeMaquina && x.Ip == ip)
                .Include(x => x.Process)
                .SingleOrDefault();
    }
}