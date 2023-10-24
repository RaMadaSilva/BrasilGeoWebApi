using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Commands.UserCommands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Interfaces.Adapter;
using BrasilGeo.Domain.Interfaces.Handlers;
using BrasilGeo.Domain.Interfaces.Repositories;
using BrasilGeo.Domain.Interfaces.Services;
using BrasilGeo.Domain.ValueObjects;

namespace BrasilGeo.Aplications.Handlers.UserHandler
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
            try
            {
                command.Valid();

                if (!command.IsValid)
                    return new CommandResult(false, "user ou senha invalida", command.Notifications);

                var userBd = await _uniteOfWork.UserRepository.GetUserByEmailWithRoleAsync(command.Email);

                var loginDto = _adapter.Adapte(command);
                loginDto.Password = "**********"; 

                if (userBd is null)
                    return new CommandResult(false, "user ou senha invalida", loginDto);

                Password senha = command.Password;

                var result = _account.ValidationPassword(senha, userBd.PasswordHash);

                if (!result)
                    return new CommandResult(false, "User ou senha invalida", loginDto);

                var token = _token.GenerateToken(userBd);

                return new CommandResult(true, "Autenticação bem sucedida", new TokenUserDto(token)); 

            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Ocorreu um erro inesperado:\n{ex.Message}", command.Notifications);
            }

        }
    }
}
