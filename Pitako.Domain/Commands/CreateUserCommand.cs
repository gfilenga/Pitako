using System;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class CreateUserCommand : ICommand
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

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}