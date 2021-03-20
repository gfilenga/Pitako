using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pitako.Domain.Entities;
using Pitako.Domain.Repositories;
using Pitako.Infra.Contexts;

namespace Pitako.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = GetById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.AsNoTracking();
        }

        public User GetById(Guid id)
        {
            return _context.Users
               .AsNoTracking()
               .Where(x => x.Id == id)
               .FirstOrDefault();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdatePassword(Guid id, string password)
        {
            throw new NotImplementedException();
        }
    }
}