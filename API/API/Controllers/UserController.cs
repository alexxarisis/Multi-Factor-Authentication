﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using API.Models.JWT.Util;
using API.Models.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("user")]
    [Authorize(Roles = "Access")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseConnector db = new();

        // Are we gonna update all together or seperately?
        [HttpPatch("update")]
        public IActionResult Update()
        {
            // update info
            return Ok("Updated profile");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete()
        {
            int id = new JWTReader(Request).GetID();
            await db.DeleteAccountAsync(id);

            return StatusCode(StatusCodes.Status410Gone,
                "Account deleted!");
        }
    }
}
