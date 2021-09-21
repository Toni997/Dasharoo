using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Controllers;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DasharooAPI.Services.Playlists
{


    public class PlaylistService : IPlaylistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public PlaylistService(IUnitOfWork unitOfWork, IMapper mapper,
             IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<bool> TryDeleteAndReturnBool(int id)
        {
            var playlist = await _unitOfWork.Playlists.Get(x => x.Id == id);
            if (playlist == null) return false;

            await _unitOfWork.Playlists.Delete(id);
            await _unitOfWork.Save();

            return true;
        }

        public async Task<ResponseDetails> TryCreateAndReturnResponseDetails(CreatePlaylistDto playlistDto, string authorId)
        {
            var playlist = _mapper.Map<Playlist>(playlistDto);
            playlist.AuthorId = authorId;

            // uploading cover image file
            if (playlistDto.Image != null)
            {
                var resultImage = await _fileService.UploadFile(
                    playlistDto.Image, _fileService.PlaylistImagesDir, FileTypes.Image);
                if (!resultImage.Succeeded) return (Error)resultImage;
                playlist.ImagePath = (string)resultImage.Value;
            }

            // uploading background image file
            if (playlistDto.Background != null)
            {
                var resultImage = await _fileService.UploadFile(
                    playlistDto.Background, _fileService.PlaylistBackgroundsDir, FileTypes.Image);
                if (!resultImage.Succeeded) return (Error)resultImage;
                playlist.BackgroundPath = (string)resultImage.Value;
            }

            await _unitOfWork.Playlists.Insert(playlist);
            await _unitOfWork.Save();

            return new Success(StatusCodes.Status201Created, playlist);
        }

        public async Task<ResponseDetails> TryUpdateAndReturnResponseDetails(int id, UpdatePlaylistDto playlistDto)
        {
            var playlist = await _unitOfWork.Playlists.Get(x => x.Id == id);
            if (playlist == null)
                return new Error(
                    StatusCodes.Status404NotFound, null);

            _mapper.Map(playlistDto, playlist);

            // uploading cover image file
            if (playlistDto.Image != null)
            {
                var resultImage = await _fileService.UploadFile(playlistDto.Image, _fileService.PlaylistImagesDir, FileTypes.Image, playlist.ImagePath);
                if (!resultImage.Succeeded) return (Error)resultImage;
                playlist.ImagePath = (string)resultImage.Value;
            }

            // uploading background image file
            if (playlistDto.Background != null)
            {
                var resultImage = await _fileService.UploadFile(playlistDto.Background, _fileService.PlaylistBackgroundsDir, FileTypes.Image, playlist.BackgroundPath);
                if (!resultImage.Succeeded) return (Error)resultImage;
                playlist.BackgroundPath = (string)resultImage.Value;
            }

            _unitOfWork.Playlists.Update(playlist);
            await _unitOfWork.Save();

            return new Success(StatusCodes.Status204NoContent, null);
        }

        public async Task<IList<PlaylistDto>> GetAllWithRecordsAndAuthor()
        {
            var playlists = await _unitOfWork.Playlists.GetAllWithRecordsAndAuthor();
            var playlistsDto = _mapper.Map<IList<PlaylistDto>>(playlists);

            return playlistsDto;
        }

        public async Task<PlaylistDto> GetByIdWithRecordsAndAuthor(int id)
        {
            var playlist = await _unitOfWork.Playlists.GetByIdWithRecordsAndAuthor(id);
            if (playlist == null) return null;

            var playlistDto = _mapper.Map<PlaylistDto>(playlist);
            return playlistDto;
        }
    }
}
