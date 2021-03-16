using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Commands
{
    public class UpdateQuestionCommand : Notifiable, ICommand
    {
        public UpdateQuestionCommand() { }

        public UpdateQuestionCommand(Guid id, string title, string description, DateTime date, User user)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasLen(Id.ToString(), 36, "Id", "Id inválido")
                .HasMinLen(Title, 2, "Name", "Please, write a title with more than 2 letters")
                .HasMaxLen(Title, 124, "Name", "Please, don't exceed 124 letters")
                .HasMinLen(Description, 2, "Description", "Please, write a description with more than 2 letters")
                .HasMaxLen(Description, 1024, "Description", "Please, don't exceed 1024 letters")
            );
        }
    }
}