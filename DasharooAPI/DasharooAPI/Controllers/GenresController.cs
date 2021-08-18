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
using DasharooAPI.Repository;
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
        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var genre = await _unitOfWork.Genres.GetById(id);

            if (genre == null) return NotFound();

            return Ok(genre);
        }

        [HttpGet("{id:int}/with-records")]
        public async Task<IActionResult> GetByIdWithRecords(int id)
        {
            return Ok(await _unitOfWork.Genres.GetByIdWithRecords(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Genres.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGenreDto genreDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(Create)}");
                return BadRequest(ModelState);
            }

            var genre = _mapper.Map<Genre>(genreDto);
            await _unitOfWork.Genres.Insert(genre);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetById",
                new { id = genre.Id }, genre);
        }

    }
}
