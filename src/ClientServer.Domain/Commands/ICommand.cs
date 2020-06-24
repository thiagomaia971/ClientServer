using MediatR;

namespace ClientServer.Domain.Commands
{
    public interface ICommand<TResult> : IRequest<CommandResult<TResult>>
    {
    }
}