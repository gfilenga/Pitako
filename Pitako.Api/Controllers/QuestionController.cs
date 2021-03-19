using Microsoft.AspNetCore.Mvc;
using Pitako.Domain.Commands;
using Pitako.Domain.Handlers;

namespace Pitako.Api.Controllers
{
    [ApiController]
    [Route("v1/questions")]
    public class QuestionController : ControllerBase
    {
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