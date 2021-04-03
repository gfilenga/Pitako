using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;

namespace Pitako.Tests.Command
{
    [TestClass]
    public class CreateAnswerTests
    {
        private readonly CreateAnswerCommand _validCommand = new CreateAnswerCommand(
            "Descrição da pergunta",
            Guid.NewGuid(),
            Guid.NewGuid()
        );
        private readonly CreateAnswerCommand _invalidCommand = new CreateAnswerCommand(
            "",
            Guid.NewGuid(),
            Guid.NewGuid()
        );

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
