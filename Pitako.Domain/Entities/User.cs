using System.Collections.Generic;

namespace Pitako.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {

        }
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public ICollection<Answer> Answers { get; private set; }
        public ICollection<Question> Questions { get; private set; }

        public void UpdateUser(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}