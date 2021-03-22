using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class ListQuestionsCommand : Notifiable, ICommand
    {
        public ListQuestionsCommand() { }
        public ListQuestionsCommand(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
            );
        }
    }
}