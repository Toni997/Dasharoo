using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Models;
using DasharooAPI.Utilities;
using Microsoft.Extensions.Hosting;

namespace DasharooAPI.Controllers
{
    public class FileService : IFileService
    {
        //dirs
        public static string rootDir = @"C:\DasharooStorage";
        public string AccountImagesDir { get; } = $@"{rootDir}\Accounts\Images";
        public string AccountBackgroundsDir { get; } = $@"{rootDir}\Accounts\Backgrounds";
        public string RecordImagesDir { get; } = $@"{rootDir}\Records\Images";
        public string RecordSourcesDir { get; } = $@"{rootDir}\Records\Sources";
        public string PlaylistImagesDir { get; } = @"C:\DasharooStorage\Playlists\Images";
        public string PlaylistBackgroundsDir { get; } = @"C:\DasharooStorage\Playlists\Backgrounds";

        //upload functions
        public async Task<ResponseDetails> UploadFile(
            IFormFile file, string uploadDir, FileTypes fileType, string fileName = null)
        {
            // check if the media file is supported
            switch (fileType)
            {
                case FileTypes.Image:
                    if (IsImageNotValid(file.FileName, file.ContentType, file.Length))
                        return new Error(StatusCodes.Status415UnsupportedMediaType,
                                "Only .jpg, .jpeg and .png images up to 20MB are supported.");
                    break;
                case FileTypes.Audio:
                    if (IsAudioNotValid(file.FileName, file.ContentType, file.Length))
                        return new Error(StatusCodes.Status415UnsupportedMediaType,
                                "Only .wav and .mp3 audio files up to 20MB are supported.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
            }

            // file uploading
            var extension = Path.GetExtension(file.FileName);
            fileName ??= Guid.NewGuid() + extension;
            var dir = Path.Combine(uploadDir, fileName);

            await using var fileStream = new FileStream(dir, FileMode.OpenOrCreate, FileAccess.Write);
            await file.CopyToAsync(fileStream);

            return new Success(StatusCodes.Status200OK, fileName);
        }

        // file extensions
        private const string Mp3 = ".mp3";
        private const string Wav = ".wav";
        private const string Png = ".png";
        private const string Jpg = ".jpg";
        private const string Jpeg = ".jpeg";
        private const string Audio = "audio";
        private const string Image = "image";

        //20 megabytes in bytes
        public const int TwentyMegabytes = 20000000;


        //helper functions
        private static bool IsImageNotValid(string fileName, string contentType, long fileSize)
        {
            return IsNotImage(contentType) || IsNotSupportedImageExtension(fileName) || IsTooLarge(fileSize);
        }

        private static bool IsAudioNotValid(string fileName, string contentType, long fileSize)
        {
            return IsNotAudio(contentType) || IsNotSupportedAudioExtension(fileName) || IsTooLarge(fileSize);
        }

        private static bool IsNotSupportedImageExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return extension is not (Jpeg or Jpg or Png);
        }

        private static bool IsNotSupportedAudioExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return extension is not (Mp3 or Wav);
        }

        private static bool IsNotAudio(string contentType)
        {
            return !contentType.Contains(Audio);
        }

        private static bool IsNotImage(string contentType)
        {
            return !contentType.Contains(Image);
        }

        private static bool IsTooLarge(long fileSize)
        {
            return fileSize > TwentyMegabytes;
        }
    }
}
