using System;
using System.Collections.Generic;

namespace Pitako.Domain.Entities
{
    public class Question : Entity
    {
        public Question()
        {

        }
        public Question(string title, string description, Guid userId)
        {
            Title = title;
            Description = description;
            Active = true;
            Date = DateTime.Now;
            UserId = userId;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public DateTime Date { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public ICollection<Answer> Answers { get; private set; }

        public void ToogleStatus()
        {
            Active = !Active;
        }

        // public void UpdateQuestion(string title, string description)
        // {
        //     Title = title;
        //     Description = description;
        // }
    }
}