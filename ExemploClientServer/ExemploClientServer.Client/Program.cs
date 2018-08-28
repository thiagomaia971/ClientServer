using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using ExemploClientServer.Hub.Client;

namespace ExemploClientServer.Client
{
    public class Program
    {
        public static TaskHubClient TaskHubClient { get; set; }

        static async Task Main(string[] args)
        {
            TaskHubClient = new TaskHubClient();

            await TaskHubClient.RegistrarComputador(Environment.MachineName, Dns.GetHostAddresses(Environment.MachineName)[0].ToString());
            var process = Process.GetProcesses();
            //Process.
            Console.ReadLine();
        }
    }
}
