using BrasilGeo.Aplications.Commands.LocationIBGECommands;
using BrasilGeo.Aplications.Handlers.LocationIBGEHandler;
using BrasilGeo.Aplications.Queries.LocationIBGEQueries;
using BrasilGeo.Domain.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BrasilGeo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationIBGEController : ControllerBase
    {

        [HttpGet("code")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocationsByCodeAsync([FromQuery] LocationIBGECodeQuery query,
            [FromServices] LocationIBGECodeQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);

            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("State")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocationByState([FromQuery] LocationIBGEStateQuery query,
            [FromServices] LocationIBGEStateQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);

            if (result is null)
                return BadRequest("Não Existem Resultados para este estado"); 
            return Ok(result);
        }

        [HttpGet("City")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocationByCityAsync([FromQuery] LocationIBGECityQuery query,
            [FromServices] LocationIBGECityQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);
            if (result is null)
                return BadRequest("Não Existem Resultados para essa Cidade");
            return Ok(result);
        }

        [HttpGet("parameters")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllLocationsAsync([FromQuery] LocationIBGEParameterQuery query,
            [FromServices] LocationIBGEWithParameterQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);

            if (result.Data.IsNullOrEmpty())
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationIBGECommand command,
            [FromServices] CreateLocationIBGEHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Success)
                return BadRequest(result);

            return Created($"/{result.Success}", result);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
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

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
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
