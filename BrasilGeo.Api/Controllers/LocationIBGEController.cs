using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Commands.LocationIBGECommands;
using BrasilGeo.Aplications.Handlers.LocationIBGEHandler;
using BrasilGeo.Aplications.Queries.LocationIBGEQueries;
using BrasilGeo.Domain.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace BrasilGeo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationIBGEController : ControllerBase
    {
        /// <summary>
        /// Retorna a localização por ID
        /// </summary>
        /// <param name="query">Requisição passando o Id</param>
        /// <returns>Mensagem de sucesso, o Id, a Cidade e o Estado</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        ///
        /// Id: 1100346
        /// </remarks>
        [HttpGet("code")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocationsByCodeAsync([FromQuery] LocationIBGECodeQuery query,
            [FromServices] LocationIBGECodeQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);

            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Retorna a localização por Estado
        /// </summary>
        /// <param name="query">Requisição passando o Estado</param>
        /// <returns>Mensagem de sucesso, uma lista com o Id, a Cidade e o Estado</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        ///
        /// State: AL
        /// </remarks>
        [HttpGet("State")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocationByState([FromQuery] LocationIBGEStateQuery query,
            [FromServices] LocationIBGEStateQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);

            if (result is null)
                return BadRequest("Não Existem Resultados para este estado");
            return Ok(result);
        }

        /// <summary>
        /// Retorna a localização por Cidade
        /// </summary>
        /// <param name="query">Requisição passando a Cidade</param>
        /// <returns>Mensagem de sucesso, uma lista com o Id, a Cidade e o Estado</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        ///
        /// City: Bragança Paulista
        /// </remarks>
        [HttpGet("City")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocationByCityAsync([FromQuery] LocationIBGECityQuery query,
            [FromServices] LocationIBGECityQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);
            if (result is null)
                return BadRequest("Não Existem Resultados para essa Cidade");
            return Ok(result);
        }

        /// <summary>
        /// Retorna a localidade por parâmetros
        /// </summary>
        /// <param name="query">Requisição passando parâmetros</param>
        /// <returns>Mensagem de sucesso, uma lista com o Id, a Cidade e o Estado</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        ///
        /// PageIndex: 1
        /// PageSize: 20
        /// Id:
        /// State: SP
        /// City:
        /// Sort:
        ///
        /// Ainda não é possível realizar a pesquisa com múltiplos parâmetros, por exemplo passando Cidade e Estado na mesma solicitação, uma melhoria a ser feita.
        /// </remarks>
        [HttpGet("parameters")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllLocationsAsync([FromQuery] LocationIBGEParameterQuery query,
            [FromServices] LocationIBGEWithParameterQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);

            if (result.Data.IsNullOrEmpty())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Cria uma localidade
        /// </summary>
        /// <param name="command">Requisição</param>
        /// <returns>Mensagem de sucesso, o Id, a Cidade e o Estado</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     POST /LocationIBGE
        ///     {
        ///        "state": MA,
        ///        "city": "Pedras Negras de Pungo Andongo"
        ///     }
        /// </remarks>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationIBGECommand command,
            [FromServices] CreateLocationIBGEHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Success)
                return BadRequest(result);

            return Created($"/{result.Success}", result);
        }

        /// <summary>
        /// Atualiza uma localidade
        /// </summary>
        /// <param name="command">Requisição</param>
        /// <returns>Mensagem de sucesso, o Id, a Cidade e o Estado</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     PUT /LocationIBGE
        ///     {
        ///        "id" : 1100346,
        ///        "state": AL,
        ///        "city": "Pedras Negras de Pungo Andongo"
        ///     }
        /// </remarks>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationIBGECommand command,
            [FromServices] UpdateLocationIBGEHandler handler)
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
        /// Deleta uma localidade
        /// </summary>
        /// <param name="command">Requisição</param>
        /// <returns>Mensagem de sucesso, o Id, a Cidade e o Estado</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     DELETE /LocationIBGE
        ///     {
        ///        "id" : 1100346
        ///     }
        /// </remarks>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLocation([FromBody] DeleteLocationIBGECommand command,
            [FromServices] DeleteLocationIBGEHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
