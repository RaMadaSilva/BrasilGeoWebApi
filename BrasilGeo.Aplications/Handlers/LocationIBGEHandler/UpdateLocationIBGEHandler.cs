﻿using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Commands.LocationIBGECommands;
using BrasilGeo.Domain.Handlers.Interfaces;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class UpdateLocationIBGEHandler : ICommandHandler<UpdateLocationIBGECommand, CommandResult>
    {
        private readonly IUniteOfWork _uniteOfWork;

        public UpdateLocationIBGEHandler(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<CommandResult> HandleAsync(UpdateLocationIBGECommand command)
        {
            try 
            {
                command.Valid();
                if (command.IsValid)
                    return new CommandResult(false, "não foi possivel atualizar a Localidade", command.Notifications);

                var locationIBGEBb = await _uniteOfWork.LocationIBGERepository.GetByIdAsync(command.Id);

                if (locationIBGEBb is null)
                    return new CommandResult(false, $"Não existe uma localidade com Id = {command.Id}", string.Empty);

                locationIBGEBb.UpdateLocationIBGE(command.State, command.City);
                await _uniteOfWork.LocationIBGERepository.UpdateAsync(locationIBGEBb);

                await _uniteOfWork.CommitAsync();

                return new CommandResult(true, "Localidade atualizada com sucesso", locationIBGEBb);
            }
            catch(Exception ex) 
            {
                return new CommandResult(false, $"Ocorreu um erro inesperado:\n{ex.Message}", command.Notifications);

            }
        }
    }
}
