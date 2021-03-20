using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class UpdateUserPasswordCommand : Notifiable, ICommand
    {
        public UpdateUserPasswordCommand() { }

        public UpdateUserPasswordCommand(Guid id, string password)
        {
            Id = id;
            Password = password;
        }

        public Guid Id { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasLen(Id.ToString(), 36, "Id", "Id inválido")
                .HasMinLen(Password, 6, "Password", "Please, write a password with more than 6 letters")
                .HasMaxLen(Password, 20, "Password", "Please, write a password with less than 20 letters")
            );
        }
    }
}