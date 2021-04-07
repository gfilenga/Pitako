// using System;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using Pitako.Domain.Commands;
// using Pitako.Domain.Entities;
// using Pitako.Domain.Handlers;
// using Pitako.Tests.Repositories;

// namespace Pitako.Tests.Handlers
// {
//     [TestClass]
//     public class CreateAnswerHandlerTests
//     {
//         private readonly AnswerHandler _handler = new AnswerHandler(new FakeAnswerRepository());
//         private readonly CreateAnswerCommand _validCommand = new CreateAnswerCommand(
//             "Descrição da pergunta",
//             Guid.NewGuid(),
//             Guid.NewGuid()
//         );
//         private readonly CreateAnswerCommand _invalidCommand = new CreateAnswerCommand(
//             "",
//             Guid.NewGuid(),
//             Guid.NewGuid()
//         );

//         [TestMethod]
//         public void ShouldStopExcecutionWhenCommandIsNotValid()
//         {
//             var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
//             Assert.AreEqual(result.Success, false);
//         }

//         [TestMethod]
//         public void ShouldExcecuteWhenCommandIsValid()
//         {
//             var result = (GenericCommandResult)_handler.Handle(_validCommand);
//             Assert.AreEqual(result.Success, true);
//         }
//     }
// }
