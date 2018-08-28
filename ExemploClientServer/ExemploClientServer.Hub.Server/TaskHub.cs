using System;
using System.Threading.Tasks;
using ExemploClientServer.Core.Interfaces.ApplicationServices;
using ExemploClientServer.Core.Models;
using Microsoft.AspNetCore.SignalR;

namespace ExemploClientServer.Hub.Server
{
    public class TaskHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IComputerApplication _computerApplication;

        public TaskHub(IComputerApplication computerApplication)
            => _computerApplication = computerApplication;

        public async Task RegistrarComputador(string nomeMaquina, string ip)
        {
            var computer = _computerApplication.RegistrarComputador(nomeMaquina, ip);
            await Clients.All.SendAsync("ComputadorAlterado", computer);
        }

        public async Task AtivarMaquina(string nomeMaquina, string ip)
        {
            var computer = _computerApplication.AtivarMaquina(nomeMaquina, ip);
            await Clients.All.SendAsync("ComputadorAlterado", computer);
        }

        public async Task DesativarMaquina(string nomeMaquina, string ip)
        {
            var computer = _computerApplication.DesativarMaquina(nomeMaquina, ip);
            await Clients.All.SendAsync("ComputadorAlterado", computer);
        }

        public async Task InformarProcessos(string machineName, string ip, Process[] processos)
        {
            try
            {
                var computer = _computerApplication.InformarProcessos(machineName, ip, processos);
                await Clients.All.SendAsync("ComputadorAlterado", computer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}