using System;

namespace Pitako.Domain.Entities
{
    public class Question : Entity
    {
        public Question(string title, string description, bool active, User user)
        {
            Title = title;
            Description = description;
            Active = true;
            User = user;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }
        public bool Active { get; private set; }
        public User User { get; private set; }

        public void ToogleStatus()
        {
            Active = !Active;
        }

        public void UpdateQuestion(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}