using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Entities;
using Pitako.Domain.Queries;

namespace Pitako.Tests.Queries
{
    [TestClass]
    public class QuestionQueriesTests
    {
        private List<Question> _questions;
        private User _user1 = new User("guilherme", "gui.filenga@hotmail.com", "1234567");
        private User _user2 = new User("Tatiana2", "tati2@hotmail.com", "1234567");

        private Question _question1;
        private Question _question2;
        private Question _question3;
        private Question _question4;
        private Question _question5;
        private Question _question6;

        public QuestionQueriesTests()
        {
            _questions = new List<Question>();
            _question1 = new Question("Ajuda1", "Preciso de um pitako1", _user1);
            _questions.Add(_question1);
            _question2 = new Question("Ajuda2", "Preciso de um pitako2", _user1);
            _questions.Add(_question2);
            _question3 = new Question("Ajuda3", "Preciso de um pitako3", _user1);
            _questions.Add(_question3);
            _question4 = new Question("Ajuda4", "Preciso de um pitako4", _user2);
            _questions.Add(_question4);
            _question5 = new Question("Ajuda5", "Preciso de um pitako5", _user2);
            _questions.Add(_question5);
            _question6 = new Question("Ajuda6", "Preciso de um pitako6", _user2);
            _questions.Add(_question6);
        }

        [TestMethod]
        public void ShouldReturnTheQuestionFromASpecificUser()
        {
            var result = _questions.AsQueryable().Where(QuestionQueries.GetAll(_user1));
            Assert.AreEqual(result.Count(), 3);
        }
        [TestMethod]
        public void ShouldReturnTheQuestionsFromASpecificUserThatAreActive()
        {
            _question1.ToogleStatus();
            var result = _questions.AsQueryable().Where(QuestionQueries.GetAllActive(_user1));
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void ShouldReturnTheQuestionsFromASpecificUserThatAreNotActive()
        {
            _question1.ToogleStatus();
            var result = _questions.AsQueryable().Where(QuestionQueries.GetAllUnactive(_user1));
            Assert.AreEqual(result.Count(), 1);
        }
    }
}