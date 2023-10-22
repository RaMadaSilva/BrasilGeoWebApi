using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Commands.UserCommands;
using BrasilGeo.Aplications.Handlers.UserHandler;
using BrasilGeo.Aplications.Queries.UserQueries;
using BrasilGeo.Domain.Commands.UserCommands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BrasilGeo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <param name="query">Vazia</param>
        /// <returns>Todos os usuários cadastrados</returns>
        /// <remarks>
        /// Para retornar todos os usuários não é necessário informar nenhum parâmetro.
        /// </remarks>
        [HttpGet]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUserAsync([FromQuery] UserQuery query,
            [FromServices] UserQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);
            return Ok(result);
        }

        /// <summary>
        /// Cria um usuário
        /// </summary>
        /// <param name="command">Requisição</param>
        /// <returns>Retorna o id, e-mail e as roles</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     POST /User
        ///     {
        ///        "email": "email@teste.com",
        ///        "password": "SenhaMaiorQue8Caracteres",
        ///        "roles": [
        ///             "Admin",
        ///             "Write",
        ///             "Reader"
        ///         ]
        ///     }
        ///     NOTA: Para Criação de um Usuario Não é necessario estar autenticado!
        /// </remarks>
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostUserAsync([FromBody] CreateUserCommand command,
            [FromServices] CreateUserHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="command">Requisição</param>
        /// <returns>Retorna o id, e-mail e as roles</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     PUT /User
        ///     {
        ///        "id" : 1,
        ///        "email": "email@teste.com",
        ///        "password": "SenhaMaiorQue8Caracteres",
        ///     }
        /// </remarks>
        [HttpPut]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutUserAsync([FromBody] UpdateuserCommand command,
            [FromServices] UpdateUserHandler handler)
        {
            try
            {
                var result = await handler.HandleAsync(command);

                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="command">Requisição</param>
        /// <returns>Retorna o id, e-mail e as roles</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     DELETE /User
        ///     {
        ///        "id": 1
        ///     }
        /// </remarks>
        [HttpDelete]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserAsync([FromBody] DeleteUserCommand command,
            [FromServices] DeleteuserHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
