using BrasilGeo.Domain.Interfaces.Commands;

namespace BrasilGeo.Domain.Interfaces.Handlers
{
    public interface ICommandHandler<TCommand, TCommandResult> where TCommand : ICommand
        where TCommandResult : ICommandResult
    {
        Task<TCommandResult> HandleAsync(TCommand command);
    }
}
