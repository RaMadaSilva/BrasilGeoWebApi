using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers
{
    public class UpdateUserHandler : ICommandHandler<UpdateuserCommand, CommandResult>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IAdapter<User, UserDto> _adapter;

        public UpdateUserHandler(IUniteOfWork uniteOfWork, IAdapter<User, UserDto> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
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
            userBb.UpdateUser(command.Email, command.Password, command.Roles);
            await _uniteOfWork.UserRepository.UpdateAsync(userBb);

            //Persiste no banco
            await _uniteOfWork.CommitAsync();

            return new CommandResult(true, "Usuario actualizado com sucesso", _adapter.Adapte(userBb)); 
        }
    }
}
