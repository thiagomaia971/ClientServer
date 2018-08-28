using System.Collections.Generic;
using ExemploClientServer.Core.Models;
using Process = ExemploClientServer.Core.Models.Process;

namespace ExemploClientServer.Core.Interfaces.ApplicationServices
{
    public interface IComputerApplication
    {
        Computer RegistrarComputador(string nomeMaquina, string ip);
        Computer AtivarMaquina(string nomeMaquina, string ip);
        Computer DesativarMaquina(string nomeMaquina, string ip);
        Computer InformarProcessos(string nomeMaquina, string ip, IEnumerable<Process> processos);
    }
}