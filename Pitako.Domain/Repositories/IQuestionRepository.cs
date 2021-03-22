using System;
using System.Collections.Generic;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Repositories
{
    public interface IQuestionRepository
    {
        void Create(Question question);
        void Update(Question question);
        void Delete(Guid id);
        Question GetById(string id);
        IEnumerable<Question> GetAll();
        IEnumerable<Question> GetAllByUser(string id);
        IEnumerable<Question> GetAllActive(User user);
        IEnumerable<Question> GetAllUnactive(User user);
        IEnumerable<Question> GetAllByPeriod(User user, DateTime date, bool active);
    }
}