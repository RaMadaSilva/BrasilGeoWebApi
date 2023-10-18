using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Handlers.LocationIBGEHandler;
using BrasilGeo.Aplications.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrasilGeo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationIBGEController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllLocationsAsync([FromQuery] LocationIBGEQuery query,
            [FromServices] LocationIBGEQueryHandler handler)
        {
            var result = await handler.HandleAsync(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationIBGECommand command, 
            [FromServices] CreateLocationIBGEHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Sucess)
                return BadRequest(result);

            return Created($"/{result.Sucess}", result);
        }

        [HttpPut]
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
        public async Task<IActionResult>  DeleteLocation([FromBody] DeleteLocationIBGECommand command,
            [FromServices] DeleteLocationIBGEHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if (!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
