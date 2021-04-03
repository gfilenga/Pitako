using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;

namespace Pitako.Tests.Entities
{
    [TestClass]
    public class AnswerTests
    {
        private readonly Answer _answer = new Answer(
                "Descrição atualizada",
                Guid.NewGuid(),
                Guid.NewGuid()
        );

        [TestMethod]
        public void ShouldStartAAnswerAsActiveTrue()
        {
            Assert.AreEqual(_answer.Active, true);
        }

        [TestMethod]
        public void ShouldToggleTheActiveProperty()
        {
            _answer.ToogleStatus();
            Assert.AreEqual(_answer.Active, false);
        }
    }
}
