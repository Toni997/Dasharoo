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

namespace DasharooAPI.Services.Genres
{
    public class GenreService : IGenreService
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;


        public GenreService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<bool> TryDeleteAndReturnBool(int id)
        {
            var genre = await _unitOfWork.Genres.GetById(id);

            if (genre == null) return false;

            await _unitOfWork.Genres.Delete(id);
            await _unitOfWork.Save();

            return true;
        }

        public async Task<ResponseDetails> TryCreateAndReturnResponseDetails(CreateGenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _unitOfWork.Genres.Insert(genre);
            await _unitOfWork.Save();

            return new Success(StatusCodes.Status201Created, genre);
        }

        public async Task<ResponseDetails> TryUpdateAndReturnResponseDetails(int id, UpdateGenreDto genreDto)
        {
            var genre = await _unitOfWork.Genres.Get(x => x.Id == id);
            if (genre == null) return new Error(StatusCodes.Status404NotFound, null);

            _mapper.Map(genreDto, genre);

            _unitOfWork.Genres.Update(genre);
            await _unitOfWork.Save();

            return new Success(StatusCodes.Status204NoContent, null);
        }

        public async Task<IList<GenreDto>> GetAll()
        {
            var genres = await _unitOfWork.Genres.GetAll();
            var genresDto = _mapper.Map<IList<GenreDto>>(genres);

            return genresDto;
        }

        public async Task<GenreDto> GetById(int id)
        {
            var genre = await _unitOfWork.Genres.GetById(id);
            if (genre == null) return null;

            var genreDto = _mapper.Map<GenreDto>(genre);
            return genreDto;
        }

        public async Task<GenreDto> GetByIdWithRecords(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdWithRecords(id);
            if (genre == null) return null;

            var genreDto = _mapper.Map<GenreDto>(genre);
            return genreDto;
        }
    }
}
