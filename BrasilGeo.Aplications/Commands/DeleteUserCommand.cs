using BrasilGeo.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilGeo.Aplications.Commands
{
    public class DeleteUserCommand : Notifiable<Notification>, ICommand
    {
        public long Id { get; set; }
        public void Valid()
        {
            AddNotifications(new Contract<DeleteUserCommand>()
                .Requires()); 
        }
    }
}
