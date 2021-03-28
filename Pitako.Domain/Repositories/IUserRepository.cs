using System;
using System.Collections.Generic;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        void Delete(Guid id);
        User Get(string name, string password);
        User GetByUsername(string username);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }
}