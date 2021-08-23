using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Utilities;
using Microsoft.Extensions.Hosting;

namespace DasharooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IHostEnvironment _env;

        public FilesController(IHostEnvironment env)
        {
            _env = env;
        }
        private static string FilesRootDir() => @"C:\Dasharoo_Files";

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            //bytes to megabytes
            const int twentyMegabytes = 20000000;
            if (file == null || file.Length > twentyMegabytes) return BadRequest();

            var extension = Path.GetExtension(file.FileName);
            if (extension != FileExtensions.Mp3
                && extension != FileExtensions.Wav)
                return BadRequest();

            var newFileName = Guid.NewGuid().ToString();

            var dir = Path.Combine(FilesRootDir(), newFileName + extension);

            await using var fileStream = new FileStream(dir, FileMode.Create, FileAccess.Write);

            await file.CopyToAsync(fileStream);

            return Ok(new { path = dir });
        }
    }
}
