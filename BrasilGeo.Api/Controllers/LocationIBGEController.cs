using BrasilGeo.Aplications.Commands.LocationIBGECommands;
using BrasilGeo.Aplications.Handlers.LocationIBGEHandler;
using BrasilGeo.Aplications.Queries.LocationIBGEQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BrasilGeo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationIBGEController : ControllerBase
    {
        [HttpGet("teste")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet("{id}")]
        [Authorize(Policy = "RequireReader")]
        public async Task<IActionResult> GetLocationsByCodeAsync([FromQuery] LocationIBGECodeQuery query,
            [FromServices] LocationIBGECodeQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);

            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Authorize(Policy = "RequireReader")]
        public async Task<IActionResult> GetAllLocationsAsync([FromQuery] LocationIBGEParameterQuery query,
            [FromServices] LocationIBGEWithParameterQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);

            if (result.IsNullOrEmpty())
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPost]
        [Authorize(Policy = "RequireWrite")]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationIBGECommand command,
            [FromServices] CreateLocationIBGEHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Sucess)
                return BadRequest(result);

            return Created($"/{result.Sucess}", result);
        }

        [HttpPut]
        [Authorize(Policy = "RequireWrite")]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationIBGECommand command,
            [FromServices] UpdateLocationIBGEHandler handler)
        {
            try
            {
                var result = await handler.HandleAsync(command);

                if (!result.Sucess)
                    return BadRequest(result);

                return Ok(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> DeleteLocation([FromBody] DeleteLocationIBGECommand command,
            [FromServices] DeleteLocationIBGEHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
