using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
using DasharooAPI.Services.Records;
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
        private readonly ILogger<RecordsController> _logger;
        private readonly IRecordService _recordService;

        public RecordsController(ILogger<RecordsController> logger, IRecordService recordService)
        {
            _logger = logger;
            _recordService = recordService;
        }

        // messages
        public const string InvalidIdMessage = "Invalid id.";

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRecords()
        {
            var recordsDto = await _recordService.GetAllWithAuthorsGenresSupporters();
            return Ok(recordsDto);
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet("Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRecordsByKeyword([FromQuery] string keyword)
        {
            var recordsDto = await _recordService.GetByKeywordWithAuthorsGenresSupporters(keyword);
            return Ok(recordsDto);
        }

        // [Authorize(Roles = UserRoles.User)]
        [HttpGet("{id:int}", Name = "GetRecordById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRecordById(int id)
        {
            var recordDto = await _recordService.GetByIdWithAuthorsGenresSupporters(id);
            if (recordDto == null) return NotFound();
            return Ok(recordDto);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRecord([FromForm] CreateRecordDto recordDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var responseDetails = await _recordService.TryCreateAndReturnResponseDetails(recordDto);
            if (!responseDetails.Succeeded)
                return StatusCode(responseDetails.StatusCode, responseDetails.Value);

            var createdRecord = (Record)responseDetails.Value;

            return CreatedAtRoute("GetRecordById",
                new { id = createdRecord.Id }, createdRecord);
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRecord(int id, [FromForm] UpdateRecordDto recordDto)
        {
            if (!ModelState.IsValid || id < 1) return BadRequest(ModelState);

            var responseDetails = await _recordService.TryUpdateAndReturnResponseDetails(id, recordDto);
            if (!responseDetails.Succeeded)
                return StatusCode(responseDetails.StatusCode, responseDetails.Value);

            return NoContent();
        }

        // [Authorize(Roles = UserRoles.Administrator)]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            if (id < 1) return BadRequest(new Error(
                    StatusCodes.Status400BadRequest, InvalidIdMessage));

            var isDeleted = await _recordService.TryDeleteAndReturnBool(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
