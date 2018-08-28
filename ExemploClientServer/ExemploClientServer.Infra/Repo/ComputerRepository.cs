using System.Linq;
using ExemploClientServer.Core.Interfaces.Repo;
using ExemploClientServer.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExemploClientServer.Infra.Repo
{
    public class ComputerRepository : Repository<Computer>, IComputerRepository
    {
        public ComputerRepository(DbContext context) : base(context)
        {
        }

        public Computer GetByNameAndIp(string nomeMaquina, string ip) 
            => GetAll(x => x.Nome == nomeMaquina && x.Ip == ip).SingleOrDefault();
    }
}