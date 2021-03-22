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

        public void Delete(Guid id)
        {
            var question = GetById(id);
            _context.Questions.Remove(question);
            _context.SaveChanges();
        }

        public IEnumerable<Question> GetAllByUser(string id)
        {
            return _context.Questions
                .AsNoTracking()
                .Where(QuestionQueries.GetAllByUser(id))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<Question> GetAllActive(User user)
        {
            return _context.Questions
                .AsNoTracking()
                .Where(QuestionQueries.GetAllActive(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<Question> GetAllByPeriod(User user, DateTime date, bool active)
        {
            return _context.Questions
                .AsNoTracking()
                .Where(QuestionQueries.GetByPeriod(user, date, active))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<Question> GetAllUnactive(User user)
        {
            return _context.Questions
                .AsNoTracking()
                .Where(QuestionQueries.GetAllUnactive(user))
                .OrderBy(x => x.Date);
        }

        public Question GetById(Guid id)
        {
            return _context.Questions
               .AsNoTracking()
               .Where(QuestionQueries.GetById(id))
               .FirstOrDefault();
        }

        public void Update(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions
                    .AsNoTracking()
                    .OrderBy(x => x.Date);
        }
    }
}