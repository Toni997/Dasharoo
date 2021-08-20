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
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.X509;

namespace DasharooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RecordsController> _logger;

        public RecordsController(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<RecordsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllRecords()
        {
            var records = await _unitOfWork.Records.GetAll(includes: new List<string> { "Genres", "Supporters" });
            var recordsDto = _mapper.Map<IList<RecordDto>>(records);
            return Ok(recordsDto);
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet("{id:int}", Name = "GetRecordById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRecordById(int id)
        {
            var record = await _unitOfWork.Records.GetById(id);
            if (record == null) return NotFound();

            var recordDto = _mapper.Map<RecordDto>(record);
            return Ok(recordDto);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateRecord([FromBody] CreateRecordDto recordDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateRecord)}");
                return BadRequest(ModelState);
            }

            var record = _mapper.Map<Record>(recordDto);
            //record.Genres = new List<Genre>();

            //foreach (var genreId in recordDto.GenresIds)
            //{
            //    var genre = await _unitOfWork.Genres.GetById(genreId);
            //    record.Genres.Add(genre);
            //}

            await _unitOfWork.Records.Insert(record);

            await _unitOfWork.Save();

            foreach (var genreId in recordDto.GenresIds)
            {
                await _unitOfWork.RecordGenre.Insert(new RecordGenre
                {
                    RecordId = record.Id,
                    GenreId = genreId,
                }); ;
            }

            await _unitOfWork.Save();


            return CreatedAtRoute("GetRecordById",
                new { id = record.Id }, record);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateRecord(int id, [FromBody] UpdateRecordDto recordDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateRecord)}");
                return BadRequest(ModelState);
            }

            var record = await _unitOfWork.Records.Get(x => x.Id == id);
            if (record == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateRecord)}");
                return BadRequest(ModelState);
            }

            _mapper.Map(recordDto, record);
            //record.Genres ??= new List<Genre>();

            //foreach (var currentGenre in record.Genres)
            //{


            //    _unitOfWork.Genres.Attach(currentGenre);
            //    if (!recordDto.GenresIds.Contains(currentGenre.Id))
            //    {
            //        record.Genres.Remove(currentGenre);
            //    }
            //}

            _unitOfWork.Records.Update(record);

            foreach (var genreId in recordDto.GenresIds)
            {
                await _unitOfWork.RecordGenre.Insert(new RecordGenre
                {
                    RecordId = record.Id,
                    GenreId = genreId,
                });
            }

            await _unitOfWork.Save();

            return NoContent();
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteRecord)}");
                return BadRequest(Error.Create(
                    StatusCodes.Status400BadRequest, "Invalid id."
                ));
            }

            var record = await _unitOfWork.Records.Get(x => x.Id == id);
            if (record == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteRecord)}");
                return BadRequest(Error.Create(
                    StatusCodes.Status400BadRequest,
                    "Record with the specified id does not exist."
                ));
            }

            await _unitOfWork.Records.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}