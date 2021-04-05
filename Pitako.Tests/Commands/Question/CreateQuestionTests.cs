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
            "Isso é um título",
            "Isso é uma descrição",
            Guid.NewGuid()
        );
        private readonly CreateQuestionCommand _invalidCommand = new CreateQuestionCommand(
                "",
                "",
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
