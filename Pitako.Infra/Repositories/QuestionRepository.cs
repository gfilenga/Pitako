using System;
using System.Collections.Generic;
using Pitako.Domain.Entities;
using Pitako.Domain.Repositories;

namespace Pitako.Infra.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public void Create(Question question)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(Question question)
        {
            throw new NotImplementedException();
        }
    }
}