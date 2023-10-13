using BrasilGeo.Aplications.Commands;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers
{
    public class CreateLocationIBGEHandler : ICommandHandler<CreateLocationIBGECommand, CommandResult>
    {
        private readonly IUniteOfWork _uinteOfWork;

        public CreateLocationIBGEHandler(IUniteOfWork uinteOfWork)
        {
            _uinteOfWork = uinteOfWork;
        }

        public Task<CommandResult> HandleAsync(CreateLocationIBGECommand command)
        {
            //command.Valid();

            //if (!command.IsValid)
            //    return new CommandResult(false, "Não foi possivel o Location", command.Notifications);

            var locationIBGE = new LocationIBGE(command.City, command.State);

            //await _uinteOfWork.UserRepository.SaveAsync(user);
            //await _uinteOfWork.CommitAsync();

            //await AssociateUserasync(user.Id, command.Roles);

            //return new CommandResult(true, "Usuario Salvo com Sucesso", user);

            throw new NotImplementedException();
        }
    }
}
