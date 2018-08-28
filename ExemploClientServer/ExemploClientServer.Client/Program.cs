using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
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
            Console.WriteLine("Iniciando...");

            var machineName = Environment.MachineName;
            var ip = Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

            Console.WriteLine($"Registrando computador {machineName} ({ip})");
            await TaskHubClient.RegistrarComputador(machineName, ip);
            Console.WriteLine($"Computador registrado {machineName} ({ip})");

            do
            {
                Console.WriteLine("Opções:");
                Console.WriteLine("1. Ativar");
                Console.WriteLine("2. Desativar");
                var value = Console.ReadLine();
                if (value == "1")
                    await TaskHubClient.AtivarMaquina(machineName, ip);
                else if (value == "2")
                    await TaskHubClient.DesativarMaquina(machineName, ip);

            } while (true);

            var process = Process.GetProcesses();
            //Process.
            Console.ReadLine();
        }
    }
}
