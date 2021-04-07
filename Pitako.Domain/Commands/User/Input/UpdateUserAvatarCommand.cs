using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class UpdateUserAvatarCommand : Notifiable, ICommand
    {
        public UpdateUserAvatarCommand() { }

        public UpdateUserAvatarCommand(string avatarB64)
        {
            AvatarB64 = avatarB64;
        }

        public string AvatarB64 { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(AvatarB64, 20, "Avatar", "Sua imagem é inválida")
            );
        }
    }
}