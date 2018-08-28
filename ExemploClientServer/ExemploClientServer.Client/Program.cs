using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ExemploClientServer.Hub.Client;

namespace ExemploClientServer.Client
{
    public class Program
    {
        private static TaskHubClient TaskHubClient { get; set; }
        private static string MachineName { get; set; }
        private static string Ip { get; set; }

        static async Task Main(string[] args)
        {
            TaskHubClient = new TaskHubClient();
            Console.WriteLine("Iniciando...");

            MachineName = Environment.MachineName;
            Ip = Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

            Console.WriteLine($"Machine Name: {MachineName}");
            Console.WriteLine($"Ip: {Ip}");

            try
            {

                Console.WriteLine($"Registrando computador");
                await TaskHubClient.RegistrarComputador(MachineName, Ip);
                Console.WriteLine($"Computador registrado");

                do
                {
                    Console.WriteLine("Opções:");
                    Console.WriteLine("1. Ativar");
                    Console.WriteLine("2. Desativar");
                    var value = Console.ReadLine();
                    if (value == "1")
                        await TaskHubClient.AtivarMaquina(MachineName, Ip);
                    else if (value == "2")
                        await TaskHubClient.DesativarMaquina(MachineName, Ip);

                } while (true);

                var process = Process.GetProcesses();
                //Process.
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
