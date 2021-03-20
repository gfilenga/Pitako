using Microsoft.AspNetCore.Mvc;
using Pitako.Domain.Commands;
using Pitako.Domain.Handlers;

namespace Pitako.Api.Controllers
{
    [ApiController]
    [Route("v1/")]
    public class TesteController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public string Get(
        )
        {
            return "Hello World!";
        }
    }
}