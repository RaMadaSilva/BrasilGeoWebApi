using BrasilGeo.Aplications.Commands;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers
{
    public class LoginHandler : ICommandHandler<LoginCommand, CommandResult>
    {
        private readonly IUniteOfWork _uniteOfWork;

        public LoginHandler(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<CommandResult> HandleAsync(LoginCommand command)
        {
            //Validar o comando
            command.Valid();

            if (!command.IsValid)
                return new CommandResult(false, "user ou senha invalida", command.Notifications);

            //caso o comando esteja correcto tenho que ir a base de dados pegar o usuario. 
            var userDb = 
            //se o usuario estiver correcto tenho que confirma a senha. 


        }
    }
}
