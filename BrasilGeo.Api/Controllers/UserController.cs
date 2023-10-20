﻿using BrasilGeo.Aplications.Commands.UserCommands;
using BrasilGeo.Aplications.Handlers.UserHandler;
using BrasilGeo.Aplications.Queries.UserQueries;
using BrasilGeo.Domain.Commands.UserCommands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrasilGeo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUserAsync([FromQuery]UserQuery query, 
            [FromServices] UserQueryHandler handler)
        {
            var result =  await handler.HandleAsync(query); 
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostUserAsync([FromBody] CreateUserCommand command, 
            [FromServices]CreateUserHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPut]
        [Authorize]
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
        [HttpDelete]
        [Authorize]
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
