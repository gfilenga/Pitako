using System;
using System.Linq.Expressions;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Queries
{
    public static class QuestionQueries
    {
        public static Expression<Func<Question, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Question, bool>> GetAllByUser(Guid id)
        {
            return x => x.UserId == id;
        }

        public static Expression<Func<Question, bool>> GetAllActive(User user)
        {
            return x => x.User.Id == user.Id && x.Active == true;
        }

        public static Expression<Func<Question, bool>> GetAllUnactive(User user)
        {
            return x => x.User.Id == user.Id && x.Active == false;
        }

        public static Expression<Func<Question, bool>> GetByPeriod(User user, DateTime date, bool active)
        {
            return x =>
                x.User.Id == user.Id &&
                x.Active == active &&
                x.Date.Date == date.Date;
        }
    }
}