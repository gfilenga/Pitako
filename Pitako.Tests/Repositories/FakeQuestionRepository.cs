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

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
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

        public IEnumerable<Question> GetAllByUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllUnactive(User user)
        {
            throw new NotImplementedException();
        }

        public Question GetById(Guid id, User user)
        {
            var user1 = new User("gui", "gui.filenga@hotmail.com", "1235678", "user");
            return new Question("AA", "AA", user.Id);
        }

        public Question GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Question question)
        {
        }
    }
}