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

        public AccountController(UserManager<User> userManager,
            ILogger<AccountController> logger, IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {
            _logger.LogInformation($"Login attempt for {userDto.Email}");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _authManager.ValidateUser(userDto)) return Unauthorized();

            var userr = await _userManager.FindByEmailAsync(userDto.Email);

            var ress = await _userManager.ConfirmEmailAsync(userr, "jajaja");

            var createdToken = new
            {
                Token = await _authManager.CreateToken()
            };

            return Accepted(createdToken);
        }

        [HttpPost]
        [Route("Signup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("no-reply@dasharoo.com"));
            email.To.Add(MailboxAddress.Parse("skuezyt@gmail.com"));
            email.Subject = "Dasharoo - Please confirm your email address";
            email.Body = new TextPart(TextFormat.Plain) { Text = $"Your confirmation token: {emailConfirmationToken}" };

            // send email
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("tkazinoti@hrcloud.com", "eypzgwnklnkmnxqm");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

            return Accepted();

        }
    }
}
