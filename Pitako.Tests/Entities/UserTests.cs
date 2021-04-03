using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;

namespace Pitako.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        private readonly User _user = new User(
            "Guilherme",
            "gui.filenga@hotmail.com",
            "1234567",
            "user"
        );

        [TestMethod]
        public void ShouldUpdateThePassword()
        {
            _user.UpdatePassword("7654321");
            Assert.AreEqual(_user.Password, "7654321");
        }
    }
}
