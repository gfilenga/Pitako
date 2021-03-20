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
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public IEnumerable<Answer> Answers { get; private set; }
        public IEnumerable<Question> Questions { get; private set; }

        public void UpdatePassword(string password)
        {
            Password = password;
        }

        public void UpdateUser(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}