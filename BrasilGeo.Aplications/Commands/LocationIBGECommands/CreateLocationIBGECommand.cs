using BrasilGeo.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BrasilGeo.Aplications.Commands.LocationIBGECommands
{
    public  class CreateLocationIBGECommand : Notifiable<Notification>, ICommand
    {
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty; 

        public void Valid()
        {
            AddNotifications(new Contract<CreateLocationIBGECommand>()
                .Requires()
                .IsGreaterThan(State, 1, "State", "Uf precisa maior que 1!")
                .IsLowerThan(State, 3, "State", "Uf precisa ter menor que 3!")
                );
        }
    }
}
