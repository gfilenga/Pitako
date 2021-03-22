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
        [Route("{id}")]
        [HttpGet]
        public Question Get(
            string id,
            [FromServices] IQuestionRepository repository
        )
        {
            return repository.GetById(id);
        }

        [Route("user/{userId}")]
        [HttpGet]
        public IEnumerable<Question> GetAllByUser(
            string userId,
            [FromServices] IQuestionRepository repository
        )
        {
            return repository.GetAllByUser(userId);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Question> GetAll(
            [FromServices] IQuestionRepository repository
        )
        {
            return repository.GetAll();
        }


        [Route("{userId}")]
        [HttpPost]
        public GenericCommandResult Create(
            string userId,
            [FromBody] CreateQuestionCommand command,
            [FromServices] QuestionHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command, userId);
        }

        [Route("{id}")]
        [HttpPut]
        public GenericCommandResult Update(
            string id,
            [FromBody] UpdateQuestionCommand command,
            [FromServices] QuestionHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command, id);
        }

        [Route("{id}")]
        [HttpDelete]
        public GenericCommandResult Delete(
            string id,
            [FromServices] IQuestionRepository repository
        )
        {
            repository.Delete(id);
            return new GenericCommandResult(
                true,
                "Pergunta deletada!",
                null
            );
        }
    }
}