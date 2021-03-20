using Microsoft.AspNetCore.Mvc;
using Pitako.Domain.Commands;
using Pitako.Domain.Handlers;

namespace Pitako.Api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}