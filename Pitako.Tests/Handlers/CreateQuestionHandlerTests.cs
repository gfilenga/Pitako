using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers;
using Pitako.Tests.Repositories;

namespace Pitako.Tests.HandlerTests
{
    [TestClass]
    public class CreateQuestionHandlerTests
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

        private readonly QuestionHandler _handler = new QuestionHandler(new FakeQuestionRepository());

        [TestMethod]
        public void ShouldStopExcecutionWhenCommandIsNotValid()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void ShouldExcecuteWhenCommandIsValid()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_handler.Valid, true);
        }
    }
}
