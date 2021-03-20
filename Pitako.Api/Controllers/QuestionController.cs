using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers;
using Pitako.Domain.Repositories;

namespace Pitako.Api.Controllers
{
    [ApiController]
    [Route("v1/questions")]
    public class QuestionController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public IEnumerable<Question> GetAll(
            [FromServices] IQuestionRepository repository,
            [FromBody] User user
        )
        {
            return repository.GetAll(user);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateQuestionCommand command,
            [FromServices] QuestionHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}