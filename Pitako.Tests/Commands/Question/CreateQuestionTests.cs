using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;

namespace Pitako.Tests.Command
{
    [TestClass]
    public class CreateQuestionTests
    {
        private readonly CreateQuestionCommand _validCommand = new CreateQuestionCommand(
                    "Vida pessoal",
                    "Preciso de uma opinião na minha vida pessoal",
                    DateTime.Now,
                    new User("Guilherme", "gui.filenga@hotmail.com", "1234567"));
        private readonly CreateQuestionCommand _invalidCommand = new CreateQuestionCommand(
                    "",
                    "",
                    DateTime.Now,
                    new User("", "", ""));

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
        [TestMethod]
        public void ShouldNotValidateWhenCommandIsNotValid()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Invalid, true);
        }
    }
}
