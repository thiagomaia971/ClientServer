using System;
using ExemploClientServer.Core.Models;

namespace ExemploClientServer.Core.Interfaces.ApplicationServices
{
    public interface IComputerApplication
    {
        Computer RegistrarComputador(string nomeMaquina, string ip);
    }
}