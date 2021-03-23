using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class AuthenticateUserCommand : Notifiable, ICommand
    {
        public AuthenticateUserCommand() { }

        public AuthenticateUserCommand(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public string Name { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 2, "Name", "Please, write a valid name")
                .HasMaxLen(Name, 254, "Name", "Please, don't exceed 254 letters")
                .HasMinLen(Password, 6, "Password", "Please, write a password with more than 6 letters")
                .HasMaxLen(Password, 20, "Password", "Please, write a password with less than 20 letters")
            );
        }
    }
}