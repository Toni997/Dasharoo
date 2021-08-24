using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Migrations;
using DasharooAPI.Models;
using DasharooAPI.Repository;
using DasharooAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace DasharooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GenresController> _logger;

        public GenresController(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<GenresController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllGenres()
        {
            var user = User.Identity.Name;
            var genres = await _unitOfWork.Genres.GetAll();
            var genresDto = _mapper.Map<IList<GenreDto>>(genres);
            return Ok(genresDto);
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet("{id:int}", Name = "GetGenreById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _unitOfWork.Genres.GetById(id);
            if (genre == null) return NotFound();

            var genreDto = _mapper.Map<GenreDto>(genre);
            return Ok(genreDto);
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet("{id:int}/with-records")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetGenreByIdWithRecords(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdWithRecords(id);
            if (genre == null) return NotFound();

            var genreDto = _mapper.Map<GenreDto>(genre);
            return Ok(genreDto);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDto genreDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateGenre)}");
                return BadRequest(ModelState);
            }

            var genre = _mapper.Map<Genre>(genreDto);
            await _unitOfWork.Genres.Insert(genre);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetGenreById",
                new { id = genre.Id }, genre);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateGenreDto genreDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateGenre)}");
                return BadRequest(ModelState);
            }

            var genre = await _unitOfWork.Genres.Get(x => x.Id == id);
            if (genre == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateGenre)}");
                return BadRequest(ModelState);
            }

            _mapper.Map(genreDto, genre);

            _unitOfWork.Genres.Update(genre);
            await _unitOfWork.Save();

            return NoContent();
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteGenre)}");
                return BadRequest(new Error(
                    StatusCodes.Status400BadRequest, "Invalid id."
                ));
            }

            var genre = await _unitOfWork.Genres.Get(x => x.Id == id);
            if (genre == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteGenre)}");
                return BadRequest(new Error(
                    StatusCodes.Status400BadRequest,
                    "Genre with the specified id does not exist."
                ));
            }

            await _unitOfWork.Genres.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}