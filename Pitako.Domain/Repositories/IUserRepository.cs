using System;
using System.Collections.Generic;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);

        IEnumerable<User> GetAll();
        void UpdatePassword(Guid id, string password);
        User GetById(Guid id);
    }
}