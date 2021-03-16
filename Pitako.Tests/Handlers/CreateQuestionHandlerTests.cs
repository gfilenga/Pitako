using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers;

namespace Pitako.Tests.HandlerTests
{
    [TestClass]
    public class CreateQuestionHandlerTests
    {
        private readonly CreateQuestionCommand _invalidCommand = new CreateQuestionCommand(
                    "",
                    "",
                    DateTime.Now,
                    new User("", "", ""));

        [TestMethod]
        public void ShouldStopExcecutionWhenCommandIsNotValid()
        {
            var handler = new QuestionHandler(null);
            Assert.AreEqual(handler.Valid, false);
        }

        [TestMethod]
        public void ShouldExcecuteWhenCommandIsValid()
        {
            Assert.Fail();
        }
    }
}
