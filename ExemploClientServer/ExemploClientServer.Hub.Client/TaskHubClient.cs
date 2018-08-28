using System;
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


        public void RegistrarMaquina(string nomeMaquina, string ip)
            => Connection.InvokeAsync("RegistrarMaquina", nomeMaquina, ip);

    }
}
