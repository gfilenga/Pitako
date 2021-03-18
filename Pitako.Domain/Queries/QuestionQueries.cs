using System;
using System.Linq.Expressions;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Queries
{
    public static class QuestionQueries
    {
        public static Expression<Func<Question, bool>> GetAll(User user)
        {
            return x => x.User.Id == user.Id;
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