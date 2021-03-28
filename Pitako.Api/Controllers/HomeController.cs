using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pitako.Domain.Commands;
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
            // Recupera o usuário pelo username
            var user = repository.GetByUsername(command.Username);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // verifica se a senha enviada na req é válida
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(command.Password, user.Password);

            // Se não for válida retorna not found
            if (!isValidPassword)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}