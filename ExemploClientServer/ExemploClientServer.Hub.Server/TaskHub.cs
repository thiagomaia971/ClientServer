using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ExemploClientServer.Hub.Server
{
    public class TaskHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public TaskHub(IRepository<Computer>)
        {
            
        }
        public async Task SendMessage(string user, string message) 
            => await Clients.All.SendAsync("ReceiveMessage", user, message);

        public async Task SendMessage(string user, string message)
            => await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}