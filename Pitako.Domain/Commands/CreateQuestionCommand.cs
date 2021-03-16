using System;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Commands
{
    public class CreateQuestionCommand : ICommand
    {
        public CreateQuestionCommand() { }
        public CreateQuestionCommand(string title, string description, DateTime date, User user)
        {
            Title = title;
            Description = description;
            Date = date;
            User = user;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}