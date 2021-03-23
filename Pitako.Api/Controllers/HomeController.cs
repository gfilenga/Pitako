using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers;
using Pitako.Domain.Repositories;
using Shop.Services;

namespace Pitako.Api.Controllers
{
    [ApiController]
    [Route("v1/")]
    public class HomeController : ControllerBase
    {
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromBody] AuthenticateUserCommand command,
            [FromServices] IUserRepository repository
        )
        {
            // Recupera o usuário
            var user = repository.Get(command.Name, command.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            // user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}