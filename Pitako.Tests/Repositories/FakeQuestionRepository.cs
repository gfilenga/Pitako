using System;
using Pitako.Domain.Entities;
using Pitako.Domain.Repositories;

namespace Pitako.Tests.Repositories
{
    public class FakeQuestionRepository : IQuestionRepository
    {
        public void Create(Question question)
        {
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