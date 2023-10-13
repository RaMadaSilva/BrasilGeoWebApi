using BrasilGeo.Domain.Commands.Interfaces;

namespace BrasilGeo.Domain.Handlers.Interfaces
{
    public interface ICommandHandler<TCommand, TCommandResult> where TCommand : ICommand 
        where TCommandResult : ICommandResult
    {
        Task<TCommandResult> HandleAsync(TCommand command);
    }
}
