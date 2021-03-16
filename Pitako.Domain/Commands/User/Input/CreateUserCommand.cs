using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public CreateUserCommand() { }

        public CreateUserCommand(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 2, "Name", "Please, write a valid name")
                .HasMaxLen(Name, 254, "Name", "Please, don't exceed 254 letters")
                .IsEmail(Email, "Email", "Please, write a valid email")
                .HasMinLen(Password, 6, "Password", "Please, write a password with more than 6 letters")
                .HasMaxLen(Password, 20, "Password", "Please, write a password with less than 20 letters")
            );
        }
    }
}