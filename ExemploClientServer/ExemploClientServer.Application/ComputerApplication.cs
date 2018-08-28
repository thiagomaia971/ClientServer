using ExemploClientServer.Core.Interfaces.ApplicationServices;
using ExemploClientServer.Core.Interfaces.Repo;
using ExemploClientServer.Core.Models;

namespace ExemploClientServer.Application
{
    public class ComputerApplication : IComputerApplication
    {
        private readonly IComputerRepository _computeRepository;

        public ComputerApplication(IComputerRepository computeRepository)
            => _computeRepository = computeRepository;

        public Computer RegistrarComputador(string nomeMaquina, string ip)
        {
            var computer = _computeRepository.GetByNameAndIp(nomeMaquina, ip);
            if (computer == null)
            {
                computer = new Computer() { Ip = ip, Nome = nomeMaquina };
                _computeRepository.Add(computer);
                _computeRepository.SaveChanges();
            }
            else
                computer.Inativo = false;

            return computer;
        }

        public Computer AtivarMaquina(string nomeMaquina, string ip) 
            => ToggleMaquina(nomeMaquina, ip, false);

        public Computer DesativarMaquina(string nomeMaquina, string ip)
            => ToggleMaquina(nomeMaquina, ip, true);


        private Computer ToggleMaquina(string nomeMaquina, string ip, bool inativo)
        {
            var computer = _computeRepository.GetByNameAndIp(nomeMaquina, ip);
            computer.Inativo = inativo;
            _computeRepository.Update(computer);
            _computeRepository.SaveChanges();

            return computer;
        }
    }
}