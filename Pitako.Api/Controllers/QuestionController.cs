using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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
        [Route("{id:guid}")]
        [HttpGet]
        public Question Get(
            Guid id,
            [FromServices] IQuestionRepository repository
        )
        {
            return repository.GetById(id);
        }

        [Route("user/{userId:guid}")]
        [HttpGet]
        public IEnumerable<Question> GetAllByUser(
            Guid userId,
            [FromServices] IQuestionRepository repository
        )
        {
            return repository.GetAllByUser(userId);
        }

        [HttpGet]
        public IEnumerable<Question> GetAll(
            [FromServices] IQuestionRepository repository
        )
        {
            return repository.GetAll();
        }

        [HttpPost]
        [Authorize]
        public GenericCommandResult Create(
            string userId,
            [FromBody] CreateQuestionCommand command,
            [FromServices] QuestionHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id:guid}")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult Update(
            Guid id,
            [FromBody] UpdateQuestionCommand command,
            [FromServices] QuestionHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command, id);
        }

        [Route("{id}")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult Delete(
            string id,
            [FromServices] IQuestionRepository repository
        )
        {
            repository.Delete(new Guid(id));
            return new GenericCommandResult(
                true,
                "Pergunta deletada!",
                null
            );
        }

        [Route("toggle/{id}")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult ToggleActiveStatus(
            string id,
            [FromServices] QuestionHandler handler
        )
        {
            return (GenericCommandResult)handler.HandleToggleStatus(new Guid(id));
        }
    }
}