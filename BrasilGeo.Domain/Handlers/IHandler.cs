using BrasilGeo.Domain.Commands.Interfaces;

namespace BrasilGeo.Domain.Handlers.Interfaces
{
    public interface IHandler<TCommand, TCommandResult> where TCommand : ICommand 
        where TCommandResult : ICommandResult
    {
        Task<TCommandResult> HandleAsync(TCommand command);
    }
}
