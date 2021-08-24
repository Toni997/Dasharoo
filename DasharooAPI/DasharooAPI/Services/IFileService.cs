using DasharooAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DasharooAPI.Controllers
{
    public interface IFileService
    {
        public string RecordSourcesDir { get; }
        public string RecordImagesDir { get; }

        Task<ResponseDetails> UploadFile(IFormFile file, string uploadDir, FileTypes fileType, string fileName = null);
    }
}