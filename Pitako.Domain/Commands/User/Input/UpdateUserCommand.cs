using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class UpdateUserCommand : Notifiable, ICommand
    {
        public UpdateUserCommand() { }

        public UpdateUserCommand(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasLen(Id.ToString(), 36, "Id", "Id inválido")
                .HasMinLen(Name, 2, "Name", "Please, write a valid name")
                .HasMaxLen(Name, 254, "Name", "Please, don't exceed 254 letters")
                .IsEmail(Email, "Email", "Please, write a valid email")
                .HasMinLen(Password, 6, "Password", "Please, write a password with more than 6 letters")
                .HasMaxLen(Password, 20, "Password", "Please, write a password with less than 20 letters")
            );
        }
    }
}