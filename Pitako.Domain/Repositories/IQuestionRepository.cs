using Pitako.Domain.Entities;

namespace Pitako.Domain.Repositories
{
    public interface IQuestionRepository
    {
        void Create(Question question);
        void Update(Question question);
    }
}