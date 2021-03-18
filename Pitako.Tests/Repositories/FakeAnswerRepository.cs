using System;
using Pitako.Domain.Entities;
using Pitako.Domain.Repositories;

namespace Pitako.Tests.Repositories
{
    public class FakeAnswerRepository : IAnswerRepository
    {
        public void Create(Answer answer)
        {
        }

        public Answer GetById(Guid id, User user)
        {
            var user1 = new User("Gui", "gui.filenga@hotmail.com", "1234567");
            var question1 = new Question("Vida pessoal", "Preciso de ajuda", new User("Gui", "gui@hotmail.com", "1235457"));
            var answer = new Answer("desc atualizada", user1, question1);
            return answer;
        }

        public Question GetQuestionById(Guid id)
        {
            var question = new Question("Vida pessoal", "Preciso de ajuda", new User("Gui", "gui@hotmail.com", "1235457"));
            return question;
        }

        public User GetUserById(Guid id)
        {
            var user = new User("Gui", "gui.filenga@hotmail.com", "1234567");
            return user;
        }

        public void Update(Answer answer)
        {
        }
    }
}