using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class DeleteAnswerCommand : Notifiable, ICommand
    {
        public DeleteAnswerCommand() { }

        public DeleteAnswerCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasLen(Id.ToString(), 36, "Id", "Id inválido")
            );
        }
    }
}