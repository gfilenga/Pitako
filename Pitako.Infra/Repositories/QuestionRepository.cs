using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pitako.Domain.Entities;
using Pitako.Domain.Queries;
using Pitako.Domain.Repositories;
using Pitako.Infra.Contexts;

namespace Pitako.Infra.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;

        public QuestionRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public IEnumerable<Question> GetAll(User user)
        {
            return _context.Questions
                .AsNoTracking()
                .Where(QuestionQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<Question> GetAllActive(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllByPeriod(User user, DateTime date, bool active)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllUnactive(User user)
        {
            throw new NotImplementedException();
        }

        public Question GetById(Guid id, User user)
        {
            throw new NotImplementedException();
        }

        public void Update(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}