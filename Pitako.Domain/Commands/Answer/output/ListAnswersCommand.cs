using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Commands
{
    public class ListAnswersCommand : Notifiable, ICommand
    {
        public ListAnswersCommand() { }
        public ListAnswersCommand(Guid questionId)
        {
            QuestionId = questionId;
        }

        public Guid QuestionId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
             );
        }
    }
}