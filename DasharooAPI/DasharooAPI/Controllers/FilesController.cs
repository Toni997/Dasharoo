using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Models;

namespace DasharooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        //messages
        public const string WrongPathMessage = "The path does not exist.";

        [HttpGet("{dir}/{type}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status206PartialContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetFile(
            [FromQuery][Required] string source, string dir, string type)
        {
            Response.Headers.Add("Accept-Ranges", "bytes");

            var stream = _fileService.GetFileStreamOrNull(source, dir, type);

            if (stream == null) return NotFound(new Error(
                StatusCodes.Status404NotFound, WrongPathMessage));

            return File(stream, "application/octet-stream");
        }
    }
}
