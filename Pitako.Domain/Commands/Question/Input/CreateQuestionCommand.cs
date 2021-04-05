using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Commands
{
    public class CreateQuestionCommand : Notifiable, ICommand
    {
        public CreateQuestionCommand() { }
        public CreateQuestionCommand(string title, string description, Guid userId)
        {
            Title = title;
            Description = description;
            Date = DateTime.Now;
            UserId = userId;
        }

        public Guid UserId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMinLen(Title, 2, "Title", "Please, write a title with more than 2 letters")
                .HasMaxLen(Title, 124, "Title", "Please, don't exceed 124 letters")
                .HasMinLen(Description, 2, "Description", "Please, write a description with more than 2 letters")
                .HasMaxLen(Description, 1024, "Description", "Please, don't exceed 1024 letters")
            );
        }
    }
}