using System;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        void UpdatePassword(Guid id, string password);
        User GetById(Guid id);
    }
}