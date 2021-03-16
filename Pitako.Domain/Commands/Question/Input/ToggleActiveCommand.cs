using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Commands
{
    public class ToggleActiveCommand : Notifiable, ICommand
    {
        public ToggleActiveCommand()
        {
        }
        public ToggleActiveCommand(Guid id, User user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public User User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasLen(Id.ToString(), 36, "Id", "Id inválido")
            );
        }
    }
}