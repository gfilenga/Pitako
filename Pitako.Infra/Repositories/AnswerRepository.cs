using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pitako.Domain.Entities;
using Pitako.Domain.Repositories;
using Pitako.Infra.Contexts;

namespace Pitako.Infra.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DataContext _context;

        public AnswerRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var answer = _context.Answers.Find(id);
            _context.Answers.Remove(answer);
            _context.SaveChanges();
        }

        public IEnumerable<Answer> GetAnswers(Guid questionId)
        {
            return _context.Answers
                    .AsNoTracking()
                    .Where(x => x.QuestionId == questionId)
                    .OrderBy(x => x.Date);
        }

        public Answer GetById(Guid id)
        {
            return _context.Answers.Find(id);
        }

        public Question GetQuestionById(Guid id)
        {
            var question = _context.Questions.Find(id);
            return question;
        }

        public User GetUserById(Guid id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public void Update(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}