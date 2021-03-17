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
                new User(
                    "Guilherme",
                    "gui.filenga@hotmail.com",
                    "1234567"),
                new Question(
                    "Vida Pessoal",
                    "Preciso de ajuda",
                    new User(
                        "Eduardo",
                        "edu.filenga@hotmail.com",
                        "1234567")
                )
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
