using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Commands.UserCommands;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Interfaces.Adapter;
using BrasilGeo.Domain.Interfaces.Handlers;
using BrasilGeo.Domain.Interfaces.Repositories;

namespace BrasilGeo.Aplications.Handlers.UserHandler
{
    public class CreateUserHandler : ICommandHandler<CreateUserCommand, CommandResult>
    {
        private readonly IUnitOfWork _uinteOfWork;
        private readonly IAdapter<User, UserDto> _adapter;

        public CreateUserHandler(IUnitOfWork uinteOfWork, IAdapter<User, UserDto> adapter)
        {
            _uinteOfWork = uinteOfWork;
            _adapter = adapter;
        }

        public async Task<CommandResult> HandleAsync(CreateUserCommand command)
        {

            try
            {
                command.Valid();

                if (!command.IsValid)
                    return new CommandResult(false, "Não foi possivel Criar o usuario", command.Notifications);
            
                var user = new User(command.Email, command.Password);

                var userBd = await _uinteOfWork.UserRepository.GetUserByEmailAsync(command.Email);

                if (user.Equals(userBd))
                    return new CommandResult(false, "Ja existe um usuario com esse email", userBd);

            

                await _uinteOfWork.UserRepository.SaveAsync(user);
                await _uinteOfWork.CommitAsync();

               await AssociateUserasync(user.Id, command.Roles);

                return new CommandResult(true, "Usuario Salvo com Sucesso", _adapter.Adapte(user)); 

            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Ocorreu um erro inesperado:\n{ex.Message}", command.Notifications);

            }
        }

        private async Task AssociateUserasync(long id, List<string> roles)
        {
            
            var result = await _uinteOfWork.UserRepository.AssociateUserToRolesAsync(id, roles);

            if(result)
               await _uinteOfWork.CommitAsync();

        }
    }
}
