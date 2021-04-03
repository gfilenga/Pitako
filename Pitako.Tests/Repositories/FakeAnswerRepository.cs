using System;
using System.Collections.Generic;
using Pitako.Domain.Entities;
using Pitako.Domain.Repositories;

namespace Pitako.Tests.Repositories
{
    public class FakeAnswerRepository : IAnswerRepository
    {
        public void Create(Answer answer)
        {
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAnswers(Guid questionId)
        {
            throw new NotImplementedException();
        }

        public Answer GetById(Guid id, User user)
        {
            var user1 = new User("Gui", "gui.filenga@hotmail.com", "1234567", "user");
            var question1 = new Question("Vida pessoal", "Preciso de ajuda", user1.Id);
            var answer = new Answer("desc atualizada", question1.Id, user1.Id);
            return answer;
        }

        public Answer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(Guid id)
        {
            var question = new Question("Vida pessoal", "Preciso de ajuda", Guid.NewGuid());
            return question;
        }

        public User GetUserById(Guid id)
        {
            var user = new User("Gui", "gui.filenga@hotmail.com", "1234567", "user");
            return user;
        }

        public void Update(Answer answer)
        {
        }
    }
}