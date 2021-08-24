using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DasharooAPI.Utilities
{
    public static class FileHelpers
    {
        // file extensions
        public const string Mp3 = ".mp3";
        public const string Wav = ".wav";
        public const string Png = ".png";
        public const string Jpg = ".jpg";
        public const string Jpeg = ".jpeg";
        public const string Audio = "audio";
        public const string Image = "image";

        //bytes to megabytes
        public const int TwentyMegabytes = 20000000;


        //helper functions
        public static bool IsImageNotValid(string fileName, string contentType)
        {
            return IsNotImage(contentType) || IsNotSupportedImageExtension(fileName);
        }

        public static bool IsAudioNotValid(string fileName, string contentType)
        {
            return IsNotAudio(contentType) || IsNotSupportedAudioExtension(fileName);
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

        private static bool IsTooLarge(long size)
        {
            return size > TwentyMegabytes;
        }

    }
}
