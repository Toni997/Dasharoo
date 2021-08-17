using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.Models;
using DasharooAPI.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;

namespace DasharooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IMessageService _emailService;

        public AccountController(UserManager<User> userManager,
            ILogger<AccountController> logger, IMapper mapper,
            IAuthManager authManager, IMessageService emailService)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _emailService = emailService;
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

            var user = await _authManager.ValidateAndReturnUser(userDto);

            if (user == null) return Unauthorized(new
            {
                Message = "Wrong credentials."
            });

            if (!user.EmailConfirmed) return Unauthorized(new
            {
                Message = "Account not confirmed."
            });

            return Accepted(new
            {
                Token = await _authManager.CreateToken()
            });
        }

        [HttpPost]
        [Route("Signup")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Signup([FromBody] SignupUserDto userDto)
        {
            _logger.LogInformation($"Registration attempt for {userDto.Email}");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _mapper.Map<User>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, new List<string> { "User" });

            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var emailToSend = new MessageToSend
            {
                Destination = user.Email,
                Subject = "Dasharoo - Confirm your account",
                Body = $"Please click <a href=\"https://localhost:44350/api/Account/ConfirmEmail/{emailConfirmationToken}\">HERE</a> to confirm your account."
            };

            await _emailService.SendAsync(emailToSend);

            return Accepted();
        }
        [HttpPut]
        [Route("ConfirmEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string username, [FromQuery] string token)
        {
            if (username == null || token == null) return BadRequest();

            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded) return BadRequest();

            user.EmailConfirmed = true;

            await _userManager.UpdateAsync(user);

            return Ok();
        }
    }
}