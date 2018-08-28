using System.Collections.Generic;
using System.Threading.Tasks;
using ExemploClientServer.Hub.Client;
using Microsoft.AspNetCore.Blazor.Components;

namespace ExemploClienteServer.App.Pages
{
    public class CounterComponent : BlazorComponent
    {
        protected int currentCount = 0;
        protected ICollection<string> itens;
        protected TaskHubClient taskHubClient;

        protected  void IncrementCount()
        {
            currentCount++;
        }

        protected void Send()
        {
            taskHubClient.ReceiveMessage(Handler);
            taskHubClient.SendMessage("user x", "message x");
        }

        void Handler(string user, string message) 
            => itens.Add($"User: {user} // Message: {message}");

        protected override Task OnInitAsync()
        {
            itens = new List<string>();
            taskHubClient = new TaskHubClient();
            return base.OnInitAsync();
        }
    }
}