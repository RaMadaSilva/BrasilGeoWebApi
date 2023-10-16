﻿using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrasilGeo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostLogin([FromBody] LoginCommand command, 
            [FromServices] LoginHandler handler)
        {
            var result = await handler.HandleAsync(command);

            if(!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
