using System;
using System.Diagnostics;
using System.Net;
using ExemploClientServer.Hub.Client;

namespace ExemploClientServer.Client
{
    public class Program
    {
        public static TaskHubClient TaskHubClient { get; set; }

        static void Main(string[] args)
        {
            TaskHubClient = new TaskHubClient();

            TaskHubClient.RegistrarMaquina(Environment.MachineName, Dns.GetHostAddresses(Environment.MachineName)[0].ToString());
            var process = Process.GetProcesses();
            //Process.
            Console.ReadLine();
        }
    }
}
