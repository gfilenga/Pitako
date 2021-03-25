using System.Collections.Generic;

namespace Pitako.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {

        }
        public User(string username, string email, string password, string role)
        {
            Username = username;
            Email = email;
            Password = password;
            Role = role;
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }

        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public string Role { get; private set; }
        public ICollection<Answer> Answers { get; private set; }
        public ICollection<Question> Questions { get; private set; }

        public void UpdateUser(string username, string email, string password, string role)
        {
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}