using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Commands
{
    public class CreateAnswerCommand : Notifiable, ICommand
    {
        public CreateAnswerCommand() { }
        public CreateAnswerCommand(string description, Guid userId, Guid questionId)
        {
            Description = description;
            UserId = userId;
            QuestionId = questionId;
        }

        public string Description { get; set; }
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMinLen(Description, 2, "Description", "Please, write a description with more than 2 letters")
                .HasMaxLen(Description, 1024, "Description", "Please, don't exceed 1024 letters")
             );
        }
    }
}