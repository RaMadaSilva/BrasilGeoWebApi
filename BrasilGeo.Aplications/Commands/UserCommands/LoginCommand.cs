using BrasilGeo.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace BrasilGeo.Aplications.Commands.UserCommands
{
    public class LoginCommand : Notifiable<Notification>, ICommand
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public void Valid()
        {
            AddNotifications(new Contract<LoginCommand>()
                .Requires()
                .IsEmail(Email, "E-mail", "Campo de Email")
                .IsGreaterThan(Password, 8, "Passwors", "Deve conter mais de 8 caracteres"));
        }
    }
}
