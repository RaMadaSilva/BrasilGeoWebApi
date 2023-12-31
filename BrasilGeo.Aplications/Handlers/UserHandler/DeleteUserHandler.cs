﻿using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Commands.UserCommands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Interfaces.Adapter;
using BrasilGeo.Domain.Interfaces.Handlers;
using BrasilGeo.Domain.Interfaces.Repositories;

namespace BrasilGeo.Aplications.Handlers.UserHandler
{
    public class DeleteuserHandler : ICommandHandler<DeleteUserCommand, CommandResult>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IAdapter<User, UserDto> _adapter; 

        public DeleteuserHandler(IUnitOfWork uniteOfWork, IAdapter<User, UserDto> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<CommandResult> HandleAsync(DeleteUserCommand command)
        {
            try 
            {
                command.Valid();

                if (!command.IsValid)
                    return new CommandResult(false, "Não é possivel remover o usuario", command.Notifications);

                 var userBd = await _uniteOfWork.UserRepository.GetByIdAsync(command.Id);

                if(userBd is null)
                    return new CommandResult(false, $"Não existe um user com Id = {command.Id}", string.Empty);

                await _uniteOfWork.UserRepository.DeleteAsync(userBd);

                await _uniteOfWork.CommitAsync();

                return new CommandResult(true, "usuario Removido com sucesso", _adapter.Adapte(userBd)); 


            }
            catch (Exception ex) 
            {
                return new CommandResult(false, $"Ocorreu um erro inesperado:\n{ex.Message}", command.Notifications);
            }

        }
    }
}
