using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploClientServer.Core.Interfaces.ApplicationServices;
using ExemploClientServer.Core.Interfaces.Repo;
using ExemploClientServer.Core.Models;
using ExemploClientServer.Hub.Client;
using Microsoft.AspNetCore.Blazor.Components;

namespace ExemploClienteServer.App.Pages
{
    public class ComputadoresPages : BlazorComponent
    {
        [Inject]
        protected IComputerRepository ComputerRepository { get; set; }
        protected Computer[] computadores;
        protected TaskHubClient taskHubClient;

        protected override Task OnInitAsync()
        {
            taskHubClient = new TaskHubClient();
            computadores = ComputerRepository.GetAll().ToArray();

            taskHubClient.ComputadorRegistrado(ComputadorRegistradoHandler);
            return base.OnInitAsync();
        }

        protected void ComputadorRegistradoHandler(Computer computer) 
            => computadores.Single(x => x.Id == computer.Id).Inativo = computer.Inativo;
    }
}