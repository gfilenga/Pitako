using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Commands
{
    public class UpdateAnswerCommand : Notifiable, ICommand
    {
        public UpdateAnswerCommand() { }

        public UpdateAnswerCommand(string description)
        {
            Description = description;
            Date = DateTime.Now;
        }

        public string Description { get; set; }
        public DateTime Date { get; set; }

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