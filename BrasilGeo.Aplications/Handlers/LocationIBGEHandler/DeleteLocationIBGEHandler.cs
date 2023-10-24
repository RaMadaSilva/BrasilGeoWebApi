using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Commands.LocationIBGECommands;
using BrasilGeo.Domain.Interfaces.Handlers;
using BrasilGeo.Domain.Interfaces.Repositories;

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
            try 
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
            catch (Exception ex)
            {
                return new CommandResult(false, $"Ocorreu um erro inesperado:\n{ex.Message}", command.Notifications);

            }
        }
    }
}
