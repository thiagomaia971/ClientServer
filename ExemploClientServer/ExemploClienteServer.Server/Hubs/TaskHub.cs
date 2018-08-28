using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ExemploClienteServer.Server.Hubs
{
    public class TaskHub : Hub
    {
        public async Task SendMessage(string user, string message) 
            => await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}