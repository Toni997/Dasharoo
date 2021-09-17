using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.HubConfig;
using DasharooAPI.Models;
using DasharooAPI.Models.Auth.Facebook;
using DasharooAPI.Services;
using DasharooAPI.Services.Auth;
using DasharooAPI.Utilities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using X.PagedList;

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
        private readonly IFileService _fileService;
        private readonly IHubContext<MyHub> _hubContext;

        public AccountController(UserManager<User> userManager,
            ILogger<AccountController> logger, IMapper mapper,
            IAuthManager authManager, IMessageService emailService,
            IFileService fileService, IHubContext<MyHub> hubContext)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _emailService = emailService;
            _fileService = fileService;
            _hubContext = hubContext;
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

            if (user == null)
                return Unauthorized(new Error(
                    StatusCodes.Status401Unauthorized, "Wrong credentials."
                ));

            if (!user.EmailConfirmed)
                return Unauthorized(new Error(
                    StatusCodes.Status401Unauthorized, "Account not confirmed."
                ));

            return Accepted(new
            {
                AccessToken = await _authManager.CreateToken(TokenTypes.AccessToken),
                RefreshToken = await _authManager.CreateToken(TokenTypes.RefreshToken)

            });
        }

        // [HttpPost]
        // [Route("Login")]
        // [ProducesResponseType(StatusCodes.Status202Accepted)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // public async Task<IActionResult> FacebookLogin([FromBody] FacebookLogin facebookLogin)
        // {
        //
        // }

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

            var tokenHtmlVersion = HttpUtility.UrlEncode(emailConfirmationToken);

            var emailToSend = new MessageToSend
            {
                Destination = user.Email,
                Subject = "Dasharoo - Confirm your account",
                Body =
                    $"Please click <a href=\"https://localhost:44350/api/Account/ConfirmEmail?username={user.UserName}&token={tokenHtmlVersion}\">HERE</a> to confirm your account."
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

        [Authorize(Roles = UserRoles.User)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = _mapper.Map<IList<GetUserDto>>(users);
            return Ok(usersDto);
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var userDto = _mapper.Map<GetUserDto>(user);

            await _hubContext.Clients.All.SendCoreAsync("ReceiveNotification", new object[] { "Somebody just loaded an user" });

            return Ok(userDto);
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAccount(string id, [FromForm] UpdateUserDto userDto)
        {
            if (!User.IsCurrentUser(id)) return Unauthorized();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByIdAsync(id);

            _mapper.Map(userDto, user);

            // uploading cover image file
            if (userDto.Image != null)
            {
                var resultImage = await _fileService.UploadFile(
                    userDto.Image, _fileService.AccountImagesDir, FileTypes.Image, user.ImagePath);
                if (resultImage.StatusCode != StatusCodes.Status200OK) return StatusCode(resultImage.StatusCode, resultImage);
                user.ImagePath = (string)resultImage.Value;
            }

            // uploading background image file
            if (userDto.Background != null)
            {
                var resultImage = await _fileService.UploadFile(
                    userDto.Background, _fileService.AccountBackgroundsDir, FileTypes.Image, user.BackgroundPath);
                if (resultImage.StatusCode != StatusCodes.Status200OK) return StatusCode(resultImage.StatusCode, resultImage);
                user.BackgroundPath = (string)resultImage.Value;
            }

            await _userManager.UpdateAsync(user);
            // await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserImage(string id, [FromForm] UserImage userImage)
        {
            if (!User.IsCurrentUser(id)) return Unauthorized();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByIdAsync(id);

            // _mapper.Map(userDto, user);

            // uploading profile image file
            if (userImage.File != null)
            {
                var resultImage = await _fileService.UploadFile(
                    userImage.File, _fileService.AccountImagesDir, FileTypes.Image, user.ImagePath);
                if (resultImage.StatusCode != StatusCodes.Status200OK) return StatusCode(resultImage.StatusCode, resultImage);
                user.ImagePath = (string)resultImage.Value;
            }

            await _userManager.UpdateAsync(user);
            // await _unitOfWork.Save();

            return NoContent();
        }
    }
}