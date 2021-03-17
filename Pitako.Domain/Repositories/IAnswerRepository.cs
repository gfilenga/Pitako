using System;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Repositories
{
    public interface IAnswerRepository
    {
        void Create(Answer question);
        void Update(Answer question);
        User GetUserById(Guid id);
        Question GetQuestionById(Guid id);
        Answer GetById(Guid id, User user);
    }
}