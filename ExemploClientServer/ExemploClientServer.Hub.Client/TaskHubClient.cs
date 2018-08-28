using System;
using System.Threading.Tasks;
using ExemploClientServer.Core.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace ExemploClientServer.Hub.Client
{
    public class TaskHubClient : HubClient
    {
        public TaskHubClient()
            : base("/taskHub")
        {
        }

        public void ReceiveMessage(Action<string, string> handler)
            => Connection.On("ReceiveMessage", handler);

        public async void SendMessage(string user, string message) 
            => await Connection.InvokeAsync("SendMessage", user, message);

        public async Task RegistrarComputador(string nomeMaquina, string ip)
            => await Connection.InvokeAsync("RegistrarComputador", nomeMaquina, ip);

        public void ComputadorRegistrado(Action<Computer> handler)
            => Connection.On("ComputadorRegistrado", handler);
    }
}
