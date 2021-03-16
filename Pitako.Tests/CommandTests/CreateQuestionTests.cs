using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;

namespace Pitako.Tests.CommandTests
{
    [TestClass]
    public class CreateQuestionTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var user = new User("Guilherme", "gui.filenga@hotmail.com", "1234567");
            var command = new CreateQuestionCommand(
                    "Vida pessoal",
                    "Preciso de uma opinião na minha vida pessoal",
                    DateTime.Now,
                    user);
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
        [TestMethod]
        public void ShouldNotValidateWhenCommandIsNotValid()
        {
            // User com password menor que 6 caracteres
            var user = new User("Guilherme", "gui.filenga@hotmail.com", "123");
            // Title com menos de 2 caracteres
            var command = new CreateQuestionCommand(
                    "V",
                    "Preciso de uma opinião na minha vida pessoal",
                    DateTime.Now,
                    user);
            command.Validate();
            Assert.AreEqual(command.Invalid, true);
        }
    }
}
