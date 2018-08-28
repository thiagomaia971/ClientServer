using ExemploClientServer.Core.Models;

namespace ExemploClientServer.Core.Interfaces.Repo
{
    public interface IComputerRepository : IRepository<Computer>
    {
        Computer GetByNameAndIp(string nomeMaquina, string ip);
    }
}