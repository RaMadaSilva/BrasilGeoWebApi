using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Commands.LocationIBGECommands;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class CreateLocationIBGEHandler : ICommandHandler<CreateLocationIBGECommand, CommandResult>
    {
        private readonly IUniteOfWork _uinteOfWork;

        public CreateLocationIBGEHandler(IUniteOfWork uinteOfWork)
        {
            _uinteOfWork = uinteOfWork;
        }

        public async Task<CommandResult> HandleAsync(CreateLocationIBGECommand command)
        {
            command.Valid();

            if (!command.IsValid)
                return new CommandResult(false, "Não foi possivel o Location", command.Notifications);

            var locationIBGE = new LocationIBGE(command.City, command.State);

            var locationIBGEBd = await _uinteOfWork.LocationIBGERepository.GetLocationIBGEByCityNameAndStateName(locationIBGE.City, locationIBGE.State);

            if (locationIBGE.Equals(locationIBGEBd))
                return new CommandResult(false, "Ja existe uma localidade com esta cidade e estado", locationIBGEBd);


            await _uinteOfWork.LocationIBGERepository.SaveAsync(locationIBGE);
            await _uinteOfWork.CommitAsync();

            return new CommandResult(true, "Localidade salva com sucesso!", locationIBGE);
        }
    }
}
