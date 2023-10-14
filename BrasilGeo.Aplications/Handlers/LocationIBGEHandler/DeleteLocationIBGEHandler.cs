using BrasilGeo.Aplications.Commands;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class DeleteLocationIBGEHandler : ICommandHandler<DeleteLocationIBGECommand, CommandResult>
    {
        private readonly IUniteOfWork _uniteOfWork;

        public DeleteLocationIBGEHandler(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<CommandResult> HandleAsync(DeleteLocationIBGECommand command)
        {
            command.Valid();

            if (!command.IsValid)
                return new CommandResult(false, "Não é possivel remover a localidade", command.Notifications);

            var locationIBGEBd = await _uniteOfWork.LocationIBGERepository.GetByIdAsync(command.Id);

            if (locationIBGEBd is null)
                return new CommandResult(false, $"Não existe uma localidade com Id = {command.Id}", string.Empty);

            await _uniteOfWork.LocationIBGERepository.DeleteAsync(locationIBGEBd);

            await _uniteOfWork.CommitAsync();

            return new CommandResult(true, "localidade Removida com sucesso", locationIBGEBd);
        }
    }
}
