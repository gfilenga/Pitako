using System;
using AutoMapper;
using Flunt.Notifications;
using Pitako.Domain.Commands;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers.Contracts;
using Pitako.Domain.Interfaces;
using Pitako.Domain.Repositories;

namespace Pitako.Domain.Handlers
{
    public class UserHandler :
        Notifiable,
        IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        private readonly IAWSS3Service _aws;

        public UserHandler(IUserRepository repository, IMapper mapper, IAWSS3Service aws)
        {
            _repository = repository;
            _mapper = mapper;
            _aws = aws;
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

            // user.UpdateUser(command.Username, command.Email, command.Password, command.Role);

            _repository.Update(_mapper.Map(command, user));

            user.Password = "";

            return new GenericCommandResult(
                true,
                "Usuário atualizado",
                user
            );
        }

        public ICommandResult Handle(UpdateUserPasswordCommand command, Guid id)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Erro ao trocar senha!",
                    command.Notifications
                );

            var user = _repository.GetById(id);

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(command.CurrentPassword, user.Password);

            if (!isValidPassword)
                return new GenericCommandResult(
                    false,
                    "Senha incorreta",
                    null
                );

            user.UpdatePassword(command.NewPassword);

            _repository.Update(user);

            user.Password = "";

            return new GenericCommandResult(
                true,
                "Senha atualizada!",
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

            // var user = new User(command.Username, command.Email, command.Password, command.Role);
            // _repository.Create(user);\

            var user = _mapper.Map<User>(command);

            _repository.Create(user);

            user.Password = "";

            return new GenericCommandResult(
                true,
                "Usuário criado",
                user
            );
        }

        public ICommandResult Handle(UpdateUserAvatarCommand command, Guid id)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Imagem inválida",
                    command.Notifications
                );

            var result = _aws.PutImgAsync(command.AvatarB64, "avatar/", id.ToString());
            var user = _repository.GetById(id);
            user.UpdateAvatar(result.Result);

            _repository.Update(user);

            return new GenericCommandResult(
                true,
                "Avatar Atualizado",
                result.Result
            );
        }
    }
}