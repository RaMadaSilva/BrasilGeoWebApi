using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;
using BrasilGeo.Domain.Services;
using BrasilGeo.Domain.ValueObjects;

namespace BrasilGeo.Aplications.Handlers
{
    public class LoginHandler : ICommandHandler<LoginCommand, CommandResult>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IGeneratorTokenService _token;
        private readonly IAccountService _account;
        private readonly IAdapter<LoginCommand, LoginDto> _adapter; 

        public LoginHandler(IUniteOfWork uniteOfWork, 
                IGeneratorTokenService token, 
                IAccountService account,
                IAdapter<LoginCommand, LoginDto> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _token = token;
            _account = account;
            _adapter = adapter;
        }

        public async Task<CommandResult> HandleAsync(LoginCommand command)
        {
            //Validar o comando
            command.Valid();

            if (!command.IsValid)
                return new CommandResult(false, "user ou senha invalida", command.Notifications);

            //caso o comando esteja correcto tenho que ir a base de dados pegar o usuario. 

            var userBd = await _uniteOfWork.UserRepository.GetUserByEmailWithRoleAsync(command.Email);

            var loginDto = _adapter.Adapte(command); 

            if (userBd is null)
                return new CommandResult(false, "user ou senha invalida", loginDto);

            //se  Existir o usuario tenho que confirma a senha. 
            Password senha = command.Password;

            var result = _account.ValidationPassword(senha, userBd.PasswordHash);

            if (!result)
                return new CommandResult(false, "User ou senha invalida", loginDto);

            var token = _token.GenerateToken(userBd);

            return new CommandResult(true, "Autenticação bem sucedida", token); 
        }
    }
}
