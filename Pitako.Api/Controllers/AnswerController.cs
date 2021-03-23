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
        [Route("question/{questionId}")]
        public IEnumerable<Answer> GetByQuestion(
            string questionId,
            [FromServices] IAnswerRepository repository
        )
        {
            return repository.GetAnswers(new Guid(questionId));
        }

        [Route("{id}")]
        [HttpDelete]
        public GenericCommandResult Delete(
            string id,
            [FromServices] IAnswerRepository repository
        )
        {
            repository.Delete(new Guid(id));
            return new GenericCommandResult(
                true,
                "Resposta deletada!",
                null
            );
        }

        [Route("{id}")]
        [HttpPut]
        public GenericCommandResult Update(
            string id,
            [FromBody] UpdateAnswerCommand command,
            [FromServices] AnswerHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command, new Guid(id));
        }
    }
}

