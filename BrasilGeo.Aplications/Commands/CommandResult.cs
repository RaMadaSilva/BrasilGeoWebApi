using BrasilGeo.Domain.Commands.Interfaces;

namespace BrasilGeo.Aplications.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool sucess, string mensage, object data)
        {
            Sucess = sucess;
            Mensage = mensage;
            Data = data;
        }

        public bool Sucess { get ; set ; }
        public string Mensage { get ; set ; }
        public object Data { get; set ; }
    }
}
