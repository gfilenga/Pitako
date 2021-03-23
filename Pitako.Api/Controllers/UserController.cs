using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers;
using Pitako.Domain.Repositories;

namespace Pitako.Api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        [Route("{id}")]
        [HttpGet]
        public User Get(
            string id,
            [FromServices] IUserRepository repository
        )
        {
            return repository.GetById(new Guid(id));
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<User> List(
            [FromServices] IUserRepository repository
        )
        {
            return repository.GetAll();
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpPut]
        public GenericCommandResult Update(
            string id,
            [FromBody] UpdateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command, new Guid(id));
        }

        [Route("{id}")]
        [HttpDelete]
        public GenericCommandResult Delete(
            string id,
            [FromServices] IUserRepository repository
        )
        {
            repository.Delete(new Guid(id));
            return new GenericCommandResult(
                true,
                "Usuário deletado!",
                null
            );
        }
    }
}