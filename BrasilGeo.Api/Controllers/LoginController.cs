using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Commands.UserCommands;
using BrasilGeo.Aplications.Handlers.UserHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BrasilGeo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Realizar o Login
        /// </summary>
        /// <param name="command">Requisição</param>
        /// <returns>Mensagem de sucesso e o token para autenticação</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     POST /Login
        ///     {
        ///        "email": email@teste.com,
        ///        "password": "SenhaMaiorQue8Caracteres"
        ///     }
        /// </remarks>
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostLogin([FromBody] LoginCommand command,
            [FromServices] LoginHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}