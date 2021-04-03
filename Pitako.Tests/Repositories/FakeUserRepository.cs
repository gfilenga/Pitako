using System;
using System.Collections.Generic;
using Pitako.Domain.Entities;
using Pitako.Domain.Repositories;

namespace Pitako.Tests.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public void Create(User user)
        {
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Get(string name, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            var user = new User("Guilherme", "gui.filenga@hotmail.com", "1234567", "user");
            return user;
        }

        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
        }

        public void UpdatePassword(Guid id, string password)
        {
        }
    }
}