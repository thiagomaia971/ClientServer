using Microsoft.AspNetCore.SignalR.Client;

namespace ExemploClientServer.Hub.Client
{
    public class HubClient
    {
        protected HubConnection Connection { get; set; }
        protected string BaseUrl { get; set; } = "http://localhost:51885";

        public HubClient(string url)
        {
            Connection = new HubConnectionBuilder().WithUrl($"{BaseUrl}/{url}").Build();
            Connection.StartAsync().GetAwaiter();
        }
    }
}
