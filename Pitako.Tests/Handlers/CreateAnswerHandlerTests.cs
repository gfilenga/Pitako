using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers;
using Pitako.Tests.Repositories;

namespace Pitako.Tests.Handlers
{
    [TestClass]
    public class CreateAnswerHandlerTests
    {
        private readonly AnswerHandler _handler = new AnswerHandler(new FakeAnswerRepository());
        private readonly CreateAnswerCommand _validCommand = new CreateAnswerCommand(
            "Descrição da pergunta",
            DateTime.Now,
            new User("Guilherme", "gui.filenga@hotmail.com", "1234567"),
            new Question("Helpppp", "Me ajudem com isso", new User("Eduardo", "edu.filenga@hotmail.com", "12345679"))
        );
        private readonly CreateAnswerCommand _invalidCommand = new CreateAnswerCommand(
            "",
            DateTime.Now,
            new User("", "", ""),
            new Question("", "", new User("", "", ""))
        );

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
            Assert.AreEqual(result.Success, true);
        }
    }
}
