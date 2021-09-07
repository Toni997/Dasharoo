using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet("{dir}/{type}")]
        public IActionResult GetFile(
            [FromQuery] string source, string dir, string type)
        {
            var src = "";
            switch (dir)
            {
                case "Accounts":
                    src = type switch
                    {
                        "Images" => _fileService.AccountImagesDir,
                        "Backgrounds" => _fileService.AccountBackgroundsDir,
                        _ => src
                    };
                    break;
                case "Playlists":
                    src = type switch
                    {
                        "Images" => _fileService.PlaylistImagesDir,
                        "Backgrounds" => _fileService.PlaylistBackgroundsDir,
                        _ => src
                    };
                    break;

                case "Records":
                    src = type switch
                    {
                        "Images" => _fileService.RecordImagesDir,
                        "Sources" => _fileService.RecordSourcesDir,
                        _ => src
                    };
                    break;
                default: return BadRequest(new Error(StatusCodes.Status400BadRequest, "The path is not correct."));
            }

            var path = Path.Combine(src, source);
            if (!System.IO.File.Exists(path)) return NotFound();

            // var filedata = await System.IO.File.ReadAllBytesAsync(path);

            Response.Headers.Add("Accept-Ranges", "bytes");

            var stream = new FileStream(
                path, FileMode.Open, FileAccess.Read, FileShare.Read,
                4096, FileOptions.Asynchronous);
            return File(stream, "application/octet-stream");
        }

    }
}
