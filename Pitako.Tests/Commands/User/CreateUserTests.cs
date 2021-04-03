using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;

namespace Pitako.Tests.Command
{
    [TestClass]
    public class CreateUserTests
    {
        private readonly CreateUserCommand _validCommand = new CreateUserCommand(
            "Guilherme",
            "gui.filenga@hotmail.com",
            "1234567",
            ""
        );
        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand(
            "",
            "",
            "",
            ""
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
