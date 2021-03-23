using System;
using System.Collections.Generic;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Repositories
{
    public interface IAnswerRepository
    {
        void Create(Answer answer);
        void Update(Answer answer);
        void Delete(Guid id);
        IEnumerable<Answer> GetAnswers(Guid questionId);
        User GetUserById(Guid id);
        Question GetQuestionById(Guid id);
        Answer GetById(Guid id);
    }
}