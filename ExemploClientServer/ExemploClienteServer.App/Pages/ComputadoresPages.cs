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
        protected ICollection<Computer> computadores;
        protected TaskHubClient taskHubClient;

        protected override Task OnInitAsync()
        {
            taskHubClient = new TaskHubClient();
            computadores = ComputerRepository.GetAll().ToArray();

            taskHubClient.ComputadorAlterado(ComputadorAlteradoHandler);
            return base.OnInitAsync();
        }

        protected void ComputadorAlteradoHandler(Computer computer)
        {
            if (computadores.All(x => x.Id != computer.Id))
                computadores.Add(computer);
            computadores
                .Single(x => x.Id == computer.Id)
                .Inativo = computer.Inativo;
            StateHasChanged();
        }
    }
}