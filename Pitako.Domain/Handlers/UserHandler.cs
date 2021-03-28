using System;
using Flunt.Notifications;
using Pitako.Domain.Commands;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers.Contracts;
using Pitako.Domain.Repositories;

namespace Pitako.Domain.Handlers
{
    public class UserHandler :
        Notifiable,
        IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(UpdateUserCommand command, Guid id)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Usuário inválido",
                    command.Notifications
                );

            var user = _repository.GetById(id);

            user.UpdateUser(command.Username, command.Email, command.Password, command.Role);

            _repository.Update(user);

            user.Password = "";

            return new GenericCommandResult(
                true,
                "Usuário atualizado",
                user
            );
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Usuário inválido",
                    command.Notifications
                );

            var user = new User(command.Username, command.Email, command.Password, command.Role);

            _repository.Create(user);

            user.Password = "";

            return new GenericCommandResult(
                true,
                "Usuário criado",
                user
            );
        }
    }
}