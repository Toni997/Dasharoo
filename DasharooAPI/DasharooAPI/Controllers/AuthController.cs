using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.Models;
using DasharooAPI.Models.Auth;
using DasharooAPI.Services.Auth;
using DasharooAPI.Services.Records;
using Microsoft.Extensions.Logging;

namespace DasharooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<RecordsController> _logger;
        public readonly IAuthService _authService;

        public AuthController(ILogger<RecordsController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {
            _logger.LogInformation($"Login attempt for {userDto.Email}");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var responseDetails = await _authService.TryLogin(userDto);
            if (!responseDetails.Succeeded)
                return Unauthorized(responseDetails);

            return Accepted((AuthorizationTokens)responseDetails.Value);
        }

        [HttpPost]
        [Route("Token")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> RefreshAccessToken(RefreshTokenDto refreshTokenDto)
        {
            _logger.LogInformation($"Refresh access token attempt for user id: {refreshTokenDto.UserId}");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var responseDetails = await _authService.RefreshAccessToken(refreshTokenDto);

            if (!responseDetails.Succeeded)
                return Unauthorized(responseDetails);

            return Accepted(new
            {
                AccessToken = (string)responseDetails.Value
            });
        }

        [HttpPost]
        [Route("Logout")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Logout([FromBody] UserIdDto userIdDto)
        {
            _logger.LogInformation($"Logout attempt for user id: {userIdDto}");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _authService.DeleteRefreshToken(userIdDto.UserId);
            return NoContent();
        }
    }
}
