using System;
using System.Collections.Generic;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Repositories
{
    public interface IQuestionRepository
    {
        void Create(Question question);
        void Update(Question question);
        Question GetById(Guid id, User user);

        IEnumerable<Question> GetAll(User user);
        IEnumerable<Question> GetAllActive(User user);
        IEnumerable<Question> GetAllUnactive(User user);
        IEnumerable<Question> GetAllByPeriod(User user, DateTime date, bool active);
    }
}