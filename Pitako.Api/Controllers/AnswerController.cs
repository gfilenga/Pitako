using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers;
using Pitako.Domain.Repositories;

namespace Pitako.Api.Controllers
{
    [ApiController]
    [Route("v1/answers")]
    public class AnswerController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Post(
            [FromBody] CreateAnswerCommand command,
            [FromServices] AnswerHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        [Route("{questionId}")]
        public IEnumerable<Answer> GetByQuestion(
            string questionId,
            [FromServices] IAnswerRepository repository
        )
        {
            return repository.GetAnswers(questionId);
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandResult Delete(
            [FromBody] DeleteAnswerCommand command,
            [FromServices] AnswerHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateAnswerCommand command,
            [FromServices] AnswerHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}

