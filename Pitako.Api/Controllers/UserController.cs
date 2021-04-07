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
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        [Route("{id:guid}")]
        [HttpGet]
        public User Get(
            Guid id,
            [FromServices] IUserRepository repository
        )
        {
            return repository.GetById(id);
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

        [Route("{id:guid}")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult Update(
            Guid id,
            [FromBody] UpdateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command, id);
        }

        [Route("password/{id:guid}")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult UpdatePassword(
            Guid id,
            [FromBody] UpdateUserPasswordCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command, id);
        }

        [Route("{id:guid}")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult Delete(
            Guid id,
            [FromServices] IUserRepository repository
        )
        {
            repository.Delete(id);
            return new GenericCommandResult(
                true,
                "Usuário deletado!",
                null
            );
        }

        [HttpPatch("avatar/{id:guid}")]
        [Authorize]
        public GenericCommandResult UpdateAvatar(
            Guid id,
            [FromBody] UpdateUserAvatarCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command, id);
        }
    }
}