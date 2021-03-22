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
    [Route("v1/questions")]
    public class QuestionController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public GenericCommandResult List(
            [FromBody] ListQuestionsCommand command,
            [FromServices] QuestionHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
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

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateQuestionCommand command,
            [FromServices] QuestionHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}