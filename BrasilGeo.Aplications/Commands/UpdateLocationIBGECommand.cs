using BrasilGeo.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace BrasilGeo.Aplications.Commands
{
    public class UpdateLocationIBGECommand : Notifiable<Notification>, ICommand
    {
        public long Id { get; set; }    
        public string State { get; set; }
        public string City { get; set; }

        public void Valid()
        {
            AddNotifications(new Contract<CreateLocationIBGECommand>()
                .Requires()
                .IsGreaterThan(State, 2, "State", "Uf precisa ter até 2 caracteres!")
                .IsLowerThan(State, 2, "State", "Uf precisa ter até 2 caracteres!")
                );
        }
    }
}
