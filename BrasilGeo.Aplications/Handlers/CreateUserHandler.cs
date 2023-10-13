using BrasilGeo.Aplications.Commands;
using BrasilGeo.Domain.Commands;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers
{
    public class CreateUserHandler : IHandler<CreateUserCommand, CommandResult>
    {
        private readonly IUniteOfWork _uinteOfWork;

        public CreateUserHandler(IUniteOfWork uinteOfWork)
        {
            _uinteOfWork = uinteOfWork;
        }

        public async Task<CommandResult> HandleAsync(CreateUserCommand command)
        {
            //Validar o comando
            command.Valid();

            //Caso o comando seja invalido
            if (!command.IsValid)
                return new CommandResult(false, "Não foi possivel Criar o usuario", command.Notifications);
            
            //caso o comando seja valido. 
            var user = new User(command.Email, command.Password);

            //Verificar se Existe um user com o mesmo email na base de dados
            var userBd = await _uinteOfWork.UserRepository.GetUserByEmailAsync(command.Email);

            if (user.Equals(userBd))
                return new CommandResult(false, "Ja existe um usuario com esse email", userBd);

            

            //Caso não existe um usuario com o mesmo email 
            await _uinteOfWork.UserRepository.SaveAsync(user);
            await _uinteOfWork.CommitAsync();

            //Associar os user aos roles
           await AssociateUserasync(user.Id, command.Roles);

            return new CommandResult(true, "Usuario Salvo com Sucesso", user); 


        }

        private async Task AssociateUserasync(long id, List<string> roles)
        {
            
            var result = await _uinteOfWork.UserRepository.AssociateUserToRolesAsync(id, roles);

            if(result)
               await _uinteOfWork.CommitAsync();

        }
    }
}
