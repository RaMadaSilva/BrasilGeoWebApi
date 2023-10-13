using BrasilGeo.Aplications.Commands;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers
{
    public class UpdateUserHandler : IHandler<UpdateuserCommand, CommandResult>
    {
        private readonly IUniteOfWork _uniteOfWork;

        public UpdateUserHandler(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<CommandResult> HandleAsync(UpdateuserCommand command)
        {
            //Validar o command
            command.Valid();

            if (command.IsValid)
                return new CommandResult(false, "não foi possivel actualizar o Usuario", command.Notifications);

            //Caso o commando esteja valido localizar o Usuario
            var userBb = await _uniteOfWork.UserRepository.GetByIdAsync(command.Id);

            //Caso o usuario não exista
            if (userBb is null)
                return new CommandResult(false, $"Não existe um usario com Id = {command.Id}", string.Empty);

            //Caso exista
             await _uniteOfWork.UserRepository.UpdateAsync(userBb);

            //Persiste no banco
            _uniteOfWork.Commit();

            return new CommandResult(true, "Usuario actualizado com sucesso", userBb); 
        }
    }
}
