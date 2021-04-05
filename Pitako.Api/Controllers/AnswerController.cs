using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public GenericCommandResult Post(
            [FromBody] CreateAnswerCommand command,
            [FromServices] AnswerHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        [Route("question/{questionId:guid}")]
        public IEnumerable<Answer> GetByQuestion(
            Guid questionId,
            [FromServices] IAnswerRepository repository
        )
        {
            return repository.GetAnswers(questionId);
        }

        [Route("{id:guid}")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult Delete(
            Guid id,
            [FromServices] IAnswerRepository repository
        )
        {
            repository.Delete(id);
            return new GenericCommandResult(
                true,
                "Resposta deletada!",
                null
            );
        }

        [Route("{id}")]
        [HttpPut]
        [Authorize]
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

