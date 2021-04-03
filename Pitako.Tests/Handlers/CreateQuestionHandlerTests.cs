using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers;
using Pitako.Tests.Repositories;

namespace Pitako.Tests.Handlers
{
    [TestClass]
    public class CreateQuestionHandlerTests
    {
        private readonly CreateQuestionCommand _validCommand = new CreateQuestionCommand(
                    "Vida pessoal",
                    "Preciso de uma opinião na minha vida pessoal"
                );
        private readonly CreateQuestionCommand _invalidCommand = new CreateQuestionCommand(
                    "",
                    ""
                );

        private readonly QuestionHandler _handler = new QuestionHandler(
                    new FakeQuestionRepository(),
                    new FakeUserRepository()
                );

        [TestMethod]
        public void ShouldStopExcecutionWhenCommandIsNotValid()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand, Guid.NewGuid());
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void ShouldExcecuteWhenCommandIsValid()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand, Guid.NewGuid());
            Assert.AreEqual(_handler.Valid, true);
        }
    }
}
