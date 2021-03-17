using System;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Repositories
{
    public interface IAnswerRepository
    {
        void Create(Answer answer);
        void Update(Answer answer);
        User GetUserById(Guid id);
        Question GetQuestionById(Guid id);
        Answer GetById(Guid id, User user);
    }
}