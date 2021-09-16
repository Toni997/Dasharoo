using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.HubConfig;
using DasharooAPI.IRepository;
using DasharooAPI.Migrations;
using DasharooAPI.Models;
using DasharooAPI.Repository;
using DasharooAPI.Services.Genres;
using DasharooAPI.Services.Records;
using DasharooAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace DasharooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> _logger;
        private readonly IGenreService _genreService;
        private readonly IHubContext<MyHub> _hubContext;

        public GenresController(ILogger<GenresController> logger, IGenreService genreService, IHubContext<MyHub> hubContext)
        {
            _logger = logger;
            _genreService = genreService;
            _hubContext = hubContext;
        }

        public const string InvalidIdMessage = "Invalid id.";


        [Authorize(Roles = UserRoles.User)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllGenres()
        {
            // var user = User.Identity.Name;
            var genresDto = await _genreService.GetAll();
            return Ok(genresDto);
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet("{id:int}", Name = "GetGenreById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genreDto = await _genreService.GetById(id);
            if (genreDto == null) return NotFound();

            return Ok(genreDto);
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet("{id:int}/with-records")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGenreByIdWithRecords(int id)
        {
            var genreDto = await _genreService.GetByIdWithRecords(id);
            if (genreDto == null) return NotFound();

            return Ok(genreDto);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDto genreDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var responseDetails = await _genreService.TryCreateAndReturnResponseDetails(genreDto);
            var createdGenre = (Genre)responseDetails.Value;

            await _hubContext.Clients.All.SendCoreAsync("GenreNotification", new object[] { "Created" });

            return CreatedAtRoute("GetGenreById",
                new { id = createdGenre.Id }, createdGenre);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateGenreDto genreDto)
        {
            if (!ModelState.IsValid || id < 1) return BadRequest(ModelState);

            var responseDetails = await _genreService.TryUpdateAndReturnResponseDetails(id, genreDto);
            if (!responseDetails.Succeeded)
                return NotFound();

            await _hubContext.Clients.All.SendCoreAsync("GenreNotification", new object[] { "Updated" });

            return NoContent();
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            if (id < 1) return BadRequest(new Error(
                StatusCodes.Status400BadRequest, InvalidIdMessage));

            var isDeleted = await _genreService.TryDeleteAndReturnBool(id);
            if (!isDeleted) return NotFound();

            await _hubContext.Clients.All.SendCoreAsync("GenreNotification", new object[] { "Deleted" });


            return NoContent();
        }
    }
}