using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
using DasharooAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DasharooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RecordsController> _logger;
        private readonly IFileService _fileService;

        public RecordsController(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<RecordsController> logger, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _fileService = fileService;
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllRecords()
        {
            var records = await _unitOfWork.Records.GetAllWithAuthorsGenresSupporters();
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
            var record = await _unitOfWork.Records.GetByIdWithAuthorsGenresSupporters(id);
            if (record == null) return NotFound();
            var recordDto = _mapper.Map<RecordDto>(record);
            return Ok(recordDto);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public async Task<IActionResult> CreateRecord([FromForm] CreateRecordDto recordDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateRecord)}");
                return BadRequest(ModelState);
            }

            var record = _mapper.Map<Record>(recordDto);

            // uploading audio file
            var resultAudio = await _fileService.UploadFile(
                recordDto.Source, _fileService.RecordSourcesDir, FileTypes.Audio);
            if (resultAudio.StatusCode != StatusCodes.Status200OK) return StatusCode(resultAudio.StatusCode, resultAudio);
            record.SourcePath = resultAudio.Value;

            // uploading image file
            if (recordDto.Image != null)
            {
                var resultImage = await _fileService.UploadFile(
                    recordDto.Image, _fileService.RecordImagesDir, FileTypes.Image);
                if (resultImage.StatusCode != StatusCodes.Status200OK) return StatusCode(resultImage.StatusCode, resultImage);
                record.ImagePath = resultImage.Value;
            }

            await _unitOfWork.Records.Insert(record);
            await _unitOfWork.Save();

            // adding related data to junction tables
            foreach (var genreId in recordDto.GenresIds)
            {
                await _unitOfWork.RecordGenres.Insert(new RecordGenre
                {
                    RecordId = record.Id,
                    GenreId = genreId,
                });
            }

            foreach (var authorId in recordDto.AuthorsIds)
            {
                await _unitOfWork.RecordAuthors.Insert(new RecordAuthor
                {
                    RecordId = record.Id,
                    AuthorId = authorId,
                });
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
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public async Task<IActionResult> UpdateRecord(int id, [FromForm] UpdateRecordDto recordDto)
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

            // uploading audio file
            if (recordDto.Source != null)
            {
                var resultAudio = await _fileService.UploadFile(
                    recordDto.Source, _fileService.RecordSourcesDir, FileTypes.Audio, record.SourcePath);
                if (resultAudio.StatusCode != StatusCodes.Status200OK) return StatusCode(resultAudio.StatusCode, resultAudio);
                record.SourcePath = resultAudio.Value;
            }

            // uploading image file
            if (recordDto.Image != null)
            {
                var resultImage = await _fileService.UploadFile(
                    recordDto.Image, _fileService.RecordImagesDir, FileTypes.Image, record.ImagePath);
                if (resultImage.StatusCode != StatusCodes.Status200OK) return StatusCode(resultImage.StatusCode, resultImage);
                record.ImagePath = resultImage.Value;
            }

            _unitOfWork.Records.Update(record);

            // updating related data
            var genresToDelete = await _unitOfWork.RecordGenres.GetAll(x => x.RecordId == id && !recordDto.GenresIds.Contains(x.GenreId));
            _unitOfWork.RecordGenres.DeleteRange(genresToDelete);

            var authorsToDelete = await _unitOfWork.RecordAuthors.GetAll(x => x.RecordId == id && !recordDto.AuthorsIds.Contains(x.AuthorId));
            _unitOfWork.RecordAuthors.DeleteRange(authorsToDelete);

            foreach (var genreId in recordDto.GenresIds)
            {
                var recordGenre = await _unitOfWork.RecordGenres.Get(x => x.RecordId == id && x.GenreId == genreId);
                if (recordGenre == null)
                {
                    await _unitOfWork.RecordGenres.Insert(new RecordGenre
                    {
                        RecordId = record.Id,
                        GenreId = genreId,
                    });
                }
            }

            foreach (var authorId in recordDto.AuthorsIds)
            {
                var recordAuthor = await _unitOfWork.RecordAuthors.Get(x => x.RecordId == id && x.AuthorId == authorId);
                if (recordAuthor == null)
                {
                    await _unitOfWork.RecordAuthors.Insert(new RecordAuthor
                    {
                        RecordId = record.Id,
                        AuthorId = authorId,
                    });
                }
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
                return BadRequest(new Error(
                    StatusCodes.Status400BadRequest, "Invalid id."
                ));
            }

            var record = await _unitOfWork.Records.Get(x => x.Id == id);
            if (record == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteRecord)}");
                return BadRequest(new Error(
                    StatusCodes.Status400BadRequest,
                    "Record with the specified id does not exist."
                ));
            }

            await _unitOfWork.Records.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpGet("Streams")]
        public async Task<IActionResult> GetRecordSource([FromQuery] string source)
        {
            var path = Path.Combine(_fileService.RecordSourcesDir, source);
            if (!System.IO.File.Exists(path)) return NotFound();

            var filedata = await System.IO.File.ReadAllBytesAsync(path);

            Response.Headers.Add("Accept-Ranges", "bytes");

            return File(filedata, "application/octet-stream");

            // var path = Path.Combine(_fileService.RecordSourcesDir, source);
            // if (!System.IO.File.Exists(path)) return NotFound();
            //
            // var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);
            // return File(stream, "application/octet-stream");
        }

        [HttpGet("Images")]
        public async Task<IActionResult> GetRecordImage([FromQuery] string image)
        {
            var path = Path.Combine(_fileService.RecordImagesDir, image);
            if (!System.IO.File.Exists(path)) return NotFound();

            var filedata = await System.IO.File.ReadAllBytesAsync(path);

            return File(filedata, "application/octet-stream");
        }
    }
}
