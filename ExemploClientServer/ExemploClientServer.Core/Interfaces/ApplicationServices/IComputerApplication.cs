using System;
using System.Threading;
using ExemploClientServer.Core.Models;

namespace ExemploClientServer.Core.Interfaces.ApplicationServices
{
    public interface IComputerApplication
    {
        Computer RegistrarComputador(string nomeMaquina, string ip);
        Computer AtivarMaquina(string nomeMaquina, string ip);
        Computer DesativarMaquina(string nomeMaquina, string ip);
    }
}