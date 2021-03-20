using System;

namespace Pitako.Domain.Entities
{
    public class Answer : Entity
    {
        private Answer()
        {
        }
        public Answer(string description, Question question, User user)
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

        public void UpdateAnswer(string description)
        {
            Description = description;
        }
    }
}