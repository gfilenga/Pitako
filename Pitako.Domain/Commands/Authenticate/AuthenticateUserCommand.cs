using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class AuthenticateUserCommand : Notifiable, ICommand
    {
        public AuthenticateUserCommand() { }

        public AuthenticateUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Username, 2, "Name", "Please, write a valid name")
                .HasMaxLen(Username, 254, "Name", "Please, don't exceed 254 letters")
                .HasMinLen(Password, 6, "Password", "Please, write a password with more than 6 letters")
                .HasMaxLen(Password, 20, "Password", "Please, write a password with less than 20 letters")
            );
        }
    }
}