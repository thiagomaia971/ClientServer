using System;
using System.Threading.Tasks;
using ExemploClientServer.Core.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Process = ExemploClientServer.Core.Models.Process;

namespace ExemploClientServer.Hub.Client
{
    public class TaskHubClient : HubClient
    {
        public TaskHubClient()
            : base("/taskHub")
        {
        }

        public void ComputadorAlterado(Action<Computer> handler)
            => Connection.On("ComputadorAlterado", handler);

        public async Task RegistrarComputador(string nomeMaquina, string ip) 
            => await Connection.InvokeAsync("RegistrarComputador", nomeMaquina, ip);

        public async Task AtivarMaquina(string machineName, string ip)
            => await Connection.InvokeAsync("AtivarMaquina", machineName, ip);

        public async Task DesativarMaquina(string machineName, string ip)
            => await Connection.InvokeAsync("DesativarMaquina", machineName, ip);

        public async Task InformarProcessos(string machineName, string ip, Process[] processos)
            => await Connection.InvokeAsync("InformarProcessos", machineName, ip, processos);
    }
}
