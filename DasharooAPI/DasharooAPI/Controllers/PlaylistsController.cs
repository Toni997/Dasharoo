using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
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

        public PlaylistsController(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<PlaylistsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllPlaylists()
        {
            var playlists = await _unitOfWork.Playlists.GetAll(includes: new List<string> { "Records" });
            var playlistsDto = _mapper.Map<IList<PlaylistDto>>(playlists);
            return Ok(playlistsDto);
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet("{id:int}", Name = "GetPlaylistById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPlaylistById(int id)
        {
            var playlist = await _unitOfWork.Playlists.GetById(id);
            if (playlist == null) return NotFound();

            var playlistDto = _mapper.Map<PlaylistDto>(playlist);
            return Ok(playlistDto);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreatePlaylist([FromBody] CreatePlaylistDto playlistDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreatePlaylist)}");
                return BadRequest(ModelState);
            }

            var playlist = _mapper.Map<Playlist>(playlistDto);
            await _unitOfWork.Playlists.Insert(playlist);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetPlaylistById",
                new { id = playlist.Id }, playlist);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> UpdatePlaylist(int id, [FromBody] UpdatePlaylistDto playlistDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdatePlaylist)}");
                return BadRequest(ModelState);
            }

            var playlist = await _unitOfWork.Playlists.Get(x => x.Id == id);
            if (playlist == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdatePlaylist)}");
                return BadRequest(ModelState);
            }

            _mapper.Map(playlistDto, playlist);

            _unitOfWork.Playlists.Update(playlist);
            await _unitOfWork.Save();

            return NoContent();
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeletePlaylist)}");
                return BadRequest(Error.Create(
                    StatusCodes.Status400BadRequest, "Invalid id."
                ));
            }

            var playlist = await _unitOfWork.Playlists.Get(x => x.Id == id);
            if (playlist == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeletePlaylist)}");
                return BadRequest(Error.Create(
                    StatusCodes.Status400BadRequest,
                    "Playlist with the specified id does not exist."
                ));
            }

            await _unitOfWork.Playlists.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
