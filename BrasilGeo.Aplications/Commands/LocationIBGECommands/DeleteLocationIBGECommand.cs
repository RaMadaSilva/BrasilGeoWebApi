using BrasilGeo.Aplications.Commands.UserCommands;
using BrasilGeo.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace BrasilGeo.Aplications.Commands.LocationIBGECommands
{
    public class DeleteLocationIBGECommand : Notifiable<Notification>, ICommand
    {
        public long Id { get; set; }

        public void Valid()
        {
            AddNotifications(new Contract<DeleteUserCommand>()
                .Requires());
        }
    }
}
