﻿using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Commands.LocationIBGECommands;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Interfaces.Handlers;
using BrasilGeo.Domain.Interfaces.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class CreateLocationIBGEHandler : ICommandHandler<CreateLocationIBGECommand, CommandResult>
    {
        private readonly IUnitOfWork _uinteOfWork;

        public CreateLocationIBGEHandler(IUnitOfWork uinteOfWork)
        {
            _uinteOfWork = uinteOfWork;
        }

        public async Task<CommandResult> HandleAsync(CreateLocationIBGECommand command)
        {
            try
            {
                command.Valid();

                if (!command.IsValid)
                    return new CommandResult(false, "Não foi possivel salvar uma Localizacao", command.Notifications);

            var locationIBGE = new LocationIBGE(command.State, command.City);

                var locationIBGEBd = await _uinteOfWork
                                .LocationIBGERepository
                                .GetLocationIBGEByCityNameAndStateNameAsync(locationIBGE.City, locationIBGE.State);

                if (locationIBGE.Equals(locationIBGEBd))
                    return new CommandResult(false, "Ja existe uma localidade com esta cidade e estado", locationIBGEBd);


                await _uinteOfWork.LocationIBGERepository.SaveAsync(locationIBGE);
                await _uinteOfWork.CommitAsync();

                return new CommandResult(true, "Localidade salva com sucesso!", locationIBGE);
            }
            catch(Exception ex) 
            {
                return new CommandResult(false, $"Ocorreu um erro inesperado:\n{ex.Message}", command.Notifications);
            }

        }
    }
}
