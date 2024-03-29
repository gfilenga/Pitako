using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;

namespace Pitako.Tests.Entities
{
    [TestClass]
    public class QuestionTests
    {
        private readonly Question _question = new Question(
                        "Vida pessoal",
                        "Preciso de um pitako",
                        Guid.NewGuid()
                        );

        [TestMethod]
        public void ShouldStartAQuestionAsActiveTrue()
        {
            Assert.AreEqual(_question.Active, true);
        }

        [TestMethod]
        public void ShouldToggleTheActiveProperty()
        {
            _question.ToogleStatus();
            Assert.AreEqual(_question.Active, false);
        }

    }
}
