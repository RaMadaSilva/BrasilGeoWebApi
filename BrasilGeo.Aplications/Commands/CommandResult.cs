using BrasilGeo.Domain.Commands.Interfaces;

namespace BrasilGeo.Aplications.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool sucess, string mensage, object data)
        {
            Success = sucess;
            Message = mensage;
            Data = data;
        }

        public bool Success { get ; set ; }
        public string Message { get ; set ; }
        public object Data { get; set ; }
    }
}
