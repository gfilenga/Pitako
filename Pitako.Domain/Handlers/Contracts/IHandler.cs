using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}