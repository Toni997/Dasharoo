using DasharooAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DasharooAPI.Controllers
{
    public interface IFileService
    {
        public string AccountImagesDir { get; }
        public string AccountBackgroundsDir { get; }
        public string RecordImagesDir { get; }
        public string RecordSourcesDir { get; }
        public string PlaylistImagesDir { get; }
        public string PlaylistBackgroundsDir { get; }

        Task<ResponseDetails> UploadFile(IFormFile file, string uploadDir, FileTypes fileType, string fileName = null);
    }
}