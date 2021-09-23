using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.HubConfig;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
using DasharooAPI.Services.Playlists;
using DasharooAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace DasharooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PlaylistsController> _logger;
        private readonly IFileService _fileService;
        private readonly IPlaylistService _playlistService;

        public PlaylistsController(ILogger<PlaylistsController> logger, IPlaylistService playlistService)
        {
            _logger = logger;
            _playlistService = playlistService;
        }

        // messages
        public const string InvalidIdMessage = "Invalid id.";

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPlaylists()
        {
            var playlistsDto = await _playlistService.GetAllWithRecordsAndAuthor();
            return Ok(playlistsDto);
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet("{id:int}", Name = "GetPlaylistById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlaylistById(int id)
        {
            var playlistDto = await _playlistService.GetByIdWithRecordsAndAuthor(id);
            if (playlistDto == null) return NotFound();
            return Ok(playlistDto);
        }

        [HttpGet("queue/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlaylistByIdForQueue(int id)
        {
            var playlistDto = await _playlistService.GetByIdWithRecordsAndAuthorForQueue(id);
            if (playlistDto == null) return NotFound();
            return Ok(playlistDto);
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePlaylist([FromForm] CreatePlaylistDto playlistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var responseDetails = await _playlistService.TryCreateAndReturnResponseDetails(playlistDto, User.GetUserId());
            if (!responseDetails.Succeeded)
                return StatusCode(responseDetails.StatusCode, responseDetails.Value);

            var createdPlaylist = (Playlist)responseDetails.Value;


            return CreatedAtRoute("GetPlaylistById",
                new { id = createdPlaylist.Id }, createdPlaylist);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePlaylist(int id, [FromForm] UpdatePlaylistDto playlistDto)
        {
            var user = User;
            if (!ModelState.IsValid || id < 1)
                return BadRequest(ModelState);

            var responseDetails = await _playlistService.TryUpdateAndReturnResponseDetails(id, playlistDto);
            if (!responseDetails.Succeeded)
                return StatusCode(responseDetails.StatusCode, responseDetails.Value);

            return NoContent();
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            if (id < 1) return BadRequest(new Error(
                    StatusCodes.Status400BadRequest, InvalidIdMessage));

            var isDeleted = await _playlistService.TryDeleteAndReturnBool(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
