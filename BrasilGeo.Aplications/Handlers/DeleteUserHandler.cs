using BrasilGeo.Aplications.Commands;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers
{
    public class DeleteuserHandler : IHandler<DeleteUserCommand, CommandResult>
    {
        private readonly IUniteOfWork _uniteOfWork;

        public DeleteuserHandler(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<CommandResult> HandleAsync(DeleteUserCommand command)
        {
            command.Valid();

            if (!command.IsValid)
                return new CommandResult(false, "Não é possivel remover o usuario", command.Notifications);

            //Caso o comando esteja valido. 
             var userBd = await _uniteOfWork.UserRepository.GetByIdAsync(command.Id);

            //Verifciar se existe no banco de dados 
            if(userBd is null)
                return new CommandResult(false, $"Não existe um user com Id = {command.Id}", string.Empty);

            //Remover da Base de dados caso exista
            await _uniteOfWork.UserRepository.DeleteAsync(userBd);

            //Persistir
            await _uniteOfWork.CommitAsync();

            return new CommandResult(true, "usuario Removido com sucesso", userBd); 

        }
    }
}
