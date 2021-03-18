using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;

namespace Pitako.Tests.Command
{
    [TestClass]
    public class UpdateUserPasswordTests
    {
        private readonly UpdateUserPasswordCommand _validCommand = new UpdateUserPasswordCommand(
            Guid.NewGuid(),
            "12345678"
        );

        private readonly UpdateUserPasswordCommand _invalidCommand = new UpdateUserPasswordCommand(
            Guid.Empty,
            "1"
        );

        [TestMethod]
        public void ShouldUpdateUserPasswordWhenCommandIsValid()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }

        [TestMethod]
        public void ShouldNotUpdateUserPasswordWhenCommandIsNotValid()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Invalid, true);
        }
    }
}
