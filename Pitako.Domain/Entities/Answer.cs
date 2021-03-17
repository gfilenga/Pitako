using System;

namespace Pitako.Domain.Entities
{
    public class Answer : Entity
    {
        public Answer(string description, User user, Question question)
        {
            Description = description;
            Active = true;
            Date = DateTime.Now;
            Question = question;
            User = user;
        }
        public string Description { get; private set; }
        public bool Active { get; private set; }

        public DateTime Date { get; private set; }
        public Question Question { get; private set; }
        public User User { get; private set; }

        public void ToogleStatus()
        {
            Active = !Active;
        }
    }
}