// using System;
// using AutoMapper;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using Pitako.Domain.Commands;
// using Pitako.Domain.Entities;
// using Pitako.Domain.Handlers;
// using Pitako.Tests.Repositories;

// namespace Pitako.Tests.Handlers
// {
//     [TestClass]
//     public class CreateUserHandlerTests
//     {
//         private readonly IMapper _mapper;
//         private readonly UserHandler _handler = new UserHandler(new FakeUserRepository());
//         private readonly CreateUserCommand _validCommand = new CreateUserCommand(
//             "Guilherme",
//             "gui.filenga@hotmail.com",
//             "1234567",
//             "user"
//         );
//         private readonly CreateUserCommand _invalidCommand = new CreateUserCommand(
//                 "",
//                 "",
//                 "",
//                 ""
//         );

//         [TestMethod]
//         public void ShouldExcecuteWhenCommandIsValid()
//         {
//             var result = (GenericCommandResult)_handler.Handle(_validCommand);
//             Assert.AreEqual(result.Success, true);
//         }

//         [TestMethod]
//         public void ShouldStopExcecutionWhenCommandIsNotValid()
//         {
//             var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
//             Assert.AreEqual(result.Success, false);
//         }
//     }
// }
