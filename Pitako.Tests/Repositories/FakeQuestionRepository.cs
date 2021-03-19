using System;
using System.Collections.Generic;
using Pitako.Domain.Entities;
using Pitako.Domain.Repositories;

namespace Pitako.Tests.Repositories
{
    public class FakeQuestionRepository : IQuestionRepository
    {
        public void Create(Question question)
        {
        }

        public IEnumerable<Question> GetAll(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllActive(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllByPeriod(User user, DateTime date, bool active)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllUnactive(User user)
        {
            throw new NotImplementedException();
        }

        public Question GetById(Guid id, User user)
        {
            var user1 = new User("gui", "gui.filenga@hotmail.com", "1235678");
            return new Question("AA", "AA", user1);
        }

        public void Update(Question question)
        {
        }
    }
}